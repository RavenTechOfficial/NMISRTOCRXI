
// BAR CHART with darkmode
let barChart;

let computedStyle = getComputedStyle(document.documentElement);
let labelColorDark = computedStyle.getPropertyValue('--dark').trim();
let labelColorLight = computedStyle.getPropertyValue('--light').trim();

if (currentMode === 'dark') {
    document.body.classList.add('dark');
    switchMode.checked = true;
    renderBarChart(labelColorLight, 'dark');
} else {
    document.body.classList.remove('dark');
    switchMode.checked = false;
    renderBarChart(labelColorDark, 'light');
}

switchMode.addEventListener('change', function () {
    if (barChart) {
        barChart.destroy();
    }

    if (this.checked) {
        document.body.classList.add('dark');
        localStorage.setItem('mode', 'dark'); // Save mode to localStorage
        renderBarChart(labelColorLight, 'dark');
    } else {
        document.body.classList.remove('dark');
        localStorage.setItem('mode', 'light'); // Save mode to localStorage
        renderBarChart(labelColorDark, 'light');
    }
});
function renderBarChart(labelColor, tooltipTheme) {
    let barChartOptions = {
        series: [
            {
                name: 'Suspect/Hold',
                data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
            },
            {
                name: 'Rejected',
                data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
            },
            {
                name: 'Condemned',
                data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
            }
        ],
        chart: {
            type: 'bar',
            height: 350,
            toolbar: {
                show: false,
            },
        },
        colors: [
            '#2e7d32',
            '#2962ff',
            '#d50000',
        ],
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded',
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            labels: {
                style: {
                    colors: labelColor,
                },
            },
        },
        yaxis: {
            title: {
                text: 'Number of Heads',
                style: {
                    color: labelColor,
                },
            },
            labels: {
                style: {
                    colors: labelColor,
                },
            },
        },
        fill: {
            opacity: 1
        },
        grid: {
            borderColor: "#55596e",
            yaxis: {
                lines: {
                    show: true,
                },
            },
            xaxis: {
                lines: {
                    show: true,
                },
            },
        },
        legend: {
            labels: {
                colors: labelColor,
            },
            show: true,
            position: "bottom",
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val + ' Heads'
                }
            },
            theme: tooltipTheme,
        }
    };

    barChart = new ApexCharts(document.querySelector("#bar-chart"), barChartOptions);
    barChart.render();
}





//Area chart JS with darkmode
let areaChart;
let labelColor = localStorage.getItem('labelColor') || labelColorDark;

renderChart(labelColor, labelColor);

switchMode.addEventListener('change', function () {
    if (areaChart) {
        areaChart.destroy();
    }

    if (this.checked) {
        document.body.classList.add('dark');
        labelColor = labelColorLight;
        localStorage.setItem('labelColor', labelColorLight);
        renderChart(labelColor, "#f5f7ff");
    } else {
        document.body.classList.remove('dark');
        labelColor = labelColorDark;
        localStorage.setItem('labelColor', labelColorDark);
        renderChart(labelColor, labelColorDark);
    }
});

function renderChart(labelColor, titleColor) {
    let areaChartOptions = {
        series: [{
            name: "Approved Meat",
            data: [150659, 864732, 94320, 112321, 141212, 103854, 10483],
        }, {
            name: "Condemned Meat",
            data: [30232, 20123, 32143, 43532, 32154, 29321, 3203],
        }],
        chart: {
            type: "area",
            background: "transparent",
            height: 350,
            stacked: false,
            toolbar: {
                show: false,
            },
        },
        colors: ["#00ab57", "#d50000"],
        xaxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
            labels: {
                style: {
                    colors: labelColor,
                },
            },
        },
        dataLabels: {
            enabled: false,
        },
        fill: {
            gradient: {
                opacityFrom: 0.4,
                opacityTo: 0.1,
                shadeIntensity: 1,
                stops: [0, 100],
                type: "vertical",
            },
            type: "gradient",
        },
        grid: {
            borderColor: "#55596e",
            yaxis: {
                lines: {
                    show: true,
                },
            },
            xaxis: {
                lines: {
                    show: true,
                },
            },
        },
        legend: {
            labels: {
                colors: labelColor,
            },
            show: true,
            position: "bottom",
        },
        markers: {
            size: 6,
            strokeColors: "#1b2635",
            strokeWidth: 3,
        },
        stroke: {
            curve: "smooth",
        },
        yaxis: [
            {
                title: {
                    text: "Approved Meat",
                    style: {
                        color: titleColor,
                    },
                },
                labels: {
                    style: {
                        colors: [labelColor],
                    },
                },
            },
            {
                opposite: true,
                title: {
                    text: "Condemned Meat",
                    style: {
                        color: titleColor,
                    },
                },
                labels: {
                    style: {
                        colors: [labelColor],
                    },
                },
            },
        ],
        tooltip: {
            shared: true,
            intersect: false,
            theme: "dark",
        }
    };

    areaChart = new ApexCharts(document.querySelector("#area-chart"), areaChartOptions);
    areaChart.render();
}




//doughnut Chart JS

const chartData = {
    labels: ["Highly Satisfied", "Satisfied", "Neutral", "Dissatisfied", "Highly Dissatisfied"],
    data: [139, 34, 13, 6, 3],
};

const myChart = document.querySelector(".my-chart");
const ul = document.querySelector(".feedback-stats .details ul");

new Chart(myChart, {
    type: "doughnut",
    data: {
        labels: chartData.labels,
        datasets: [
            {
                label: "   Total Feedbacks",
                data: chartData.data,
            },
        ],
    },
    options: {
        borderWidth: 4,
        borderRadius: 2,
        hoverBorderWidth: 0,
        plugins: {
            legend: {
                display: false,
            },
        },
    },
});

const populateUl = () => {
    const totalVotes = chartData.data.reduce((acc, curr) => acc + curr, 0);

    chartData.labels.forEach((l, i) => {
        const percentage = (chartData.data[i] / totalVotes) * 100;

        let li = document.createElement("li");
        li.innerHTML = `${l}: <span class='percentage'>${percentage.toFixed(2)}%</span>`;
        ul.appendChild(li);
    });
};

populateUl();

