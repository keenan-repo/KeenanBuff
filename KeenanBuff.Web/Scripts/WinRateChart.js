var WinRateChart = WinRateChart || (function () {
    var _args = {}; // private

    return {
        init: function (Args) {
            _args = Args;
        },
        drawChart: function () {

            //Create SVG and set widths etc
            var chartDiv = document.getElementById("winrate-chart");
            var svg = d3.select(chartDiv).append("svg");

            var svgWidth = chartDiv.clientWidth;
            var svgHeight = document.getElementById("most-played-heroes").clientHeight;

            var margin = { top: 20, right: 20, bottom: 30, left: 50 };

            svg.attr("width", svgWidth)
                .attr("height", svgHeight);

            var width = svgWidth - margin.left - margin.right;
            var height = svgHeight - margin.top - margin.bottom;

            g = svg.append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")")
                .attr("width", width)
                .attr("height", height);


            var x = d3.scaleTime().rangeRound([0, width]);
            var y = d3.scaleLinear().rangeRound([height, 0]);

            // date / time parser
            var parseTime = d3.timeParse("%d-%b-%y");

            var div = g.append("div")
                .attr("class", "tooltip")
                .style("opacity", 0);


            // gridlines in y axis function
            function make_y_gridlines() {
                return d3.axisLeft(y)
                    .ticks(5);
            }

            // gridlines in y axis function
            function make_x_gridlines() {
                return d3.axisBottom(x)
                    .ticks(5);
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

            g.append("g")
                .attr("class", "grid")
                .call(make_x_gridlines()
                .tickSize(height)
                .tickFormat("")
            );
            g.append("g")
                .attr("class", "grid")
                .call(make_y_gridlines()
                .tickSize(-width)
                .tickFormat("")
            );

            // Add the X Axis
            g.append("g")
                .attr("transform", "translate(0," + height + ")")
                .call(d3.axisBottom(x).ticks(d3.timeMonth, 1)
                    .tickFormat(d3.timeFormat('%b')))
                .select(".domain")
                .attr("stroke", "#0a0a0a");

            // Add the Y Axis
            g.append("g")
                .call(d3.axisLeft(y))
                .select(".domain")
                .attr("stroke", "#0a0a0a")
                .append("text")
                .attr("stroke", "#0a0a0a");


            //recolor the labels. TODO move this
            d3.selectAll('g.tick').select("text").attr("fill", "#596269");

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
        }
    };
}());
