var WinRateChart = WinRateChart || (function () {
    var _args = {}; // private

    return {
        init: function (Args) {
            _args = Args;
            // some other initialising
        },
        drawChart: function () {

            var svg = d3.select(_args[1]),
                margin = { top: 20, right: 20, bottom: 30, left: 50 },
                width = +svg.attr("width") - margin.left - margin.right,
                height = +svg.attr("height") - margin.top - margin.bottom,
                g = svg.append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")");

            var x = d3.scaleTime().rangeRound([0, width]);

            var y = d3.scaleLinear().rangeRound([height, 0]);

            // parse the date / time
            var parseTime = d3.timeParse("%d-%b-%y");

            var div = d3.select("body").append("div")
                .attr("class", "tooltip")
                .style("opacity", 0);


            // gridlines in y axis function
            function make_y_gridlines() {
                return d3.axisLeft(y)
                    .ticks(5)
            }


            data.forEach(function (d) {
                d.Date = new Date(d.Date);
                d.WinRate = +d.WinRate;
            });

            x.domain(d3.extent(data, function (d) { return d.Date; }));
            y.domain([d3.min(data, function (d) { return d.WinRate; }), d3.max(data, function (d) { return d.WinRate; })]);

            var line = d3.line()
                .x(function (d) { return x(d.Date); })
                .y(function (d) { return y(d.WinRate); });

            /*g.call(make_y_gridlines()
                .tickSize(-width)
                .tickFormat("")   
            )*/

            // Add the X Axis
            g.append("g")
                .attr("transform", "translate(0," + height + ")")
                .call(d3.axisBottom(x).ticks(d3.timeMonth, 1)
                    .tickFormat(d3.timeFormat('%b')))
                .select(".domain")
                .attr("stroke", "#0a0a0a")

            // Add the Y Axis
            g.append("g")
                .call(d3.axisLeft(y))
                .select(".domain")
                .attr("stroke", "#0a0a0a")
                .append("text")
                .attr("stroke", "#0a0a0a")

            //draw grid lines
           /* d3.selectAll('g.tick').select("line").attr("stroke", "#0a0a0a")
                .attr("stroke-opacity", "0.7")
                .attr("shape-rendering", "crispEdges")
                .attr("z-index", 100)*/

            d3.selectAll('g.tick').select("text").attr("fill", "#596269")

            // Add the valueline path.
            g.append("path")
                .attr("fill", "none")
                .attr("stroke", "#d9d9d9")
                .attr("stroke-linejoin", "round")
                .attr("stroke-linecap", "round")
                .attr("stroke-width", 1.5)
                .attr("class", "line")
                .attr("d", line(data));


            // Add the scatterplot
            g.selectAll("dot")
                .data(data)
                .enter().append("circle")
                .attr("r", 5)
                .attr("z-index", 1100)
                .attr("fill", "white")
                .attr("fill-opacity", "0.3")
                .attr("cursor", "pointer")
                .attr("cx", function (d) { return x(d.Date); })
                .attr("cy", function (d) { return y(d.WinRate); })
                .on("mouseover", function (d) {
                    div.transition()
                        .duration(100)
                        .style("opacity", 1);
                    div.html(d.Date.toLocaleDateString("en-US") + "<br/>" + d.WinRate)
                        .style("left", (d3.event.pageX) + "px")
                        .style("top", (d3.event.pageY - 40) + "px");
                    
                })
                .on("mouseout", function (d) {
                    div.transition()
                        .duration(500)
                        .style("opacity", 0);
                });





            
                
                

            



           /* d3.csv(_args[0], function (d) {
                d.date = new Date(d.date);
                d.name = d.name;
                d.debit = +d.debit;
                d.balance = +d.balance;
                d.credit = +d.credit;
                return d;
            }, function (error, data) {
                if (error) throw error;

                x.domain(d3.extent(data, function (d) { return d.date; }));
                y.domain([0, d3.max(data, function (d) { return d.balance; })]);

                var barWidth = width / data.length;


                g.selectAll("dot")
                    .data(data)
                    .enter().append("circle")
                    .attr("r", 2)
                    .attr("cx", function (d) { return x(d.date); })
                    .attr("cy", function (d) { return y(d.balance); })
                    .on("mouseover", function (d) {
                        div.transition()
                            .duration(100)
                            .style("opacity", .9);
                        div.html(d.date + "<br/>" + d.balance)
                            .style("left", (d3.event.pageX) + "px")
                            .style("top", (d3.event.pageY - 28) + "px");
                    })
                    .on("mouseout", function (d) {
                        div.transition()
                            .duration(500)
                            .style("opacity", 0);
                    });


                // add the X gridlines
                /*svg.append("g")
                    .attr("class", "grid")
                    .attr("fill", "#000")
                    .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
                    .call(make_x_gridlines()
                        .tickSize(height)
                        .tickFormat("")
                        
                    )

                // add the Y gridlines
                svg.append("g")
                    .attr("class", "grid")
                    .attr("fill", "#000")
                    .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
                    .call(make_y_gridlines()
                        .tickSize(-width)
                        .tickFormat("")
                    )

                // Add the X Axis
                g.append("g")
                    .attr("transform", "translate(0," + height + ")")
                    .call(d3.axisBottom(x))
                    .select(".domain")
                    .remove();

                // Add the Y Axis
                g.append("g")
                    .call(d3.axisLeft(y))
                    .append("text")
                    .attr("fill", "#000")
                    .attr("transform", "rotate(-90)")
                    .attr("y", 8)
                    .attr("dy", "0.71em")
                    .attr("text-anchor", "end")
                    .text("Balance ($)");



                // Add the bars
                g.selectAll(".bar")
                    .data(data)
                    .enter().append("rect")
                    .style("fill", "#0065d8")
                    .attr('stroke', '#000000')
                    .attr("x", function (d) { return x(d.date); })
                    .attr("width", barWidth / 2)
                    .attr("y", function (d) { return y(d.debit); })
                    .attr("height", function (d) { return height - y(d.debit); }) //just add 6, don't question it

                //height = 450, 

                //Add the line
                g.append("path")
                    .datum(data)
                    .attr("fill", "none")
                    .attr("stroke", "steelblue")
                    .attr("stroke-linejoin", "round")
                    .attr("stroke-linecap", "round")
                    .attr("stroke-width", 1.5)
                    .attr("d", line);

            });*/

        }
    };
}());
