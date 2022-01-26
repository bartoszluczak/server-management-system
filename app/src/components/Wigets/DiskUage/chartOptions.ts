const options = {
  plugins: {
    legend: {
      display: false,
    },
    tooltip: {
      enabled: false,
      external: function (context: any) {
        let tooltipEl = document.getElementById("chartjs-tooltip");

        // Create element on first render
        if (!tooltipEl) {
          tooltipEl = document.createElement("div");
          tooltipEl.id = "chartjs-tooltip";
          tooltipEl.innerHTML = "<table class='tooltipBody'></table>";
          document.body.appendChild(tooltipEl);
        }

        // Hide if no tooltip
        const tooltipModel = context.tooltip;
        if (tooltipModel.opacity === 0) {
          tooltipEl.style.opacity = "0";
          return;
        }

        // Set caret Position
        tooltipEl.classList.remove("above", "below", "no-transform");
        if (tooltipModel.yAlign) {
          tooltipEl.classList.add(tooltipModel.yAlign);
        } else {
          tooltipEl.classList.add("no-transform");
        }

        function getBody(bodyItem: any) {
          return bodyItem.lines[0].split(":")[1].trim();
        }

        if (tooltipModel.body) {
          const bodyLines = tooltipModel.body.map(getBody);

          let innerHtml = "<tbody>";

          bodyLines.forEach(function (body: any, i: number) {
            innerHtml += "<tr><td>" + body + " %</td></tr>";
          });
          innerHtml += "</tbody>";

          let tableRoot = tooltipEl.querySelector("table");

          if (tableRoot) {
            tableRoot.innerHTML = innerHtml;
          }
        }

        const position = context.chart.canvas.getBoundingClientRect();

        // Display, position, and set styles for font
        tooltipEl.style.opacity = "1";
        tooltipEl.style.position = "absolute";
        tooltipEl.style.left =
          position.left + window.pageXOffset + tooltipModel.caretX + "px";
        tooltipEl.style.top =
          position.top + window.pageYOffset + tooltipModel.caretY + "px";
        tooltipEl.style.padding =
          tooltipModel.padding + "px " + tooltipModel.padding + "px";
        tooltipEl.style.pointerEvents = "none";
      },
    },
  },
};

export default options;
