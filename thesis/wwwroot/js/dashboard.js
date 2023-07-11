//Dropdown
$("li").mouseover(function () {
    $(this).find('.drop-down').slideDown(100);
    $(this).find(".accent").addClass("animate");
    $(this).find(".item").css("color", "var(--light");
}).mouseleave(function () {
    $(this).find(".drop-down").slideUp(100);
    $(this).find(".accent").removeClass("animate");
    $(this).find(".item").css("color", "var(--dark)");
});

$(document).ready(function () {
    var dropdownItems = $('.drop-down a');
    var dropdownTitleText = $('.item .item-text');  // target the span element, not the whole link

    dropdownItems.on('click', function (e) {
        e.preventDefault();
        var chosenOption = $(this).text();
        dropdownTitleText.text(chosenOption);

        // Close the dropdown immediately after a click
        $(this).closest('.drop-down').hide();
    });
});

// BAR CHART with darkmode
let barChart;

// Get the current CSS properties
let computedStyle = getComputedStyle(document.documentElement);
let labelColorDark = computedStyle.getPropertyValue('--dark').trim();
let labelColorLight = computedStyle.getPropertyValue('--light').trim();

renderBarChart(labelColorDark, 'light');

switchMode.addEventListener('change', function () {
    if (barChart) {
        barChart.destroy();
    }

    if (this.checked) {
        document.body.classList.add('dark');
        renderBarChart(labelColorLight, 'dark');
    } else {
        document.body.classList.remove('dark');
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
let timeFrame = 'daily'; // Default time frame

renderChart(labelColorDark, labelColorDark, timeFrame);

switchMode.addEventListener('change', function () {
    if (areaChart) {
        areaChart.destroy();
    }

    if (this.checked) {
        document.body.classList.add('dark');
        renderChart(labelColorLight, "#f5f7ff", timeFrame);
    } else {
        document.body.classList.remove('dark');
        renderChart(labelColorDark, labelColorDark, timeFrame);
    }
});

function renderChart(labelColor, titleColor, timeFrame) {
    let data = [];
    let categories = [];

    switch (timeFrame) {
        case 'yearly':
            data = [
                {
                    name: "Approved Meat",
                    data: [4132814, 3165489, 3143721, 4159327, 3124596, 4186543, 3598651],
                },
                {
                    name: "Condemned Meat",
                    data: [917232, 820123, 811143, 913532, 815154, 912321, 813203],
                },
            ];
            categories = ['2020', '2021', '2022', '2023', '2024', '2025', '2026'];
            break;
        case 'monthly':
            data = [
                {
                    name: "Approved Meat",
                    data: [310468, 282584, 292557, 214852, 287546, 349963, 311189],
                },
                {
                    name: "Condemned Meat",
                    data: [31232, 35123, 29143, 25532, 31154, 25121, 31103],
                },
            ];
            categories = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'];
            break;
        case 'daily':
            data = [
                {
                    name: "Approved Meat",
                    data: [12452, 15563, 16483, 14825, 17947, 14214, 13921, 16489, 11874, 16285, 16257, 15456, 13296, 11745, 15638, 17654, 16895, 11782, 13874, 13857],
                },
                {
                    name: "Condemned Meat",
                    data: [1260, 1263, 1258, 1272, 1249, 1255, 1269, 1251, 1274, 1266, 1247, 1263, 1271, 1249, 1267, 1268, 1260, 1270, 1258, 1265],
                },
            ];
            categories = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20'];
            break;
        case 'hourly':
            data = [
                {
                    name: "Approved Meat",
                    data: [482, 345, 396, 423, 368, 410, 392, 446, 491, 408, 432, 461, 389, 415, 477, 435, 372, 415, 488, 446, 408, 465, 439, 456],
                },
                {
                    name: "Condemned Meat",
                    data: [45, 53, 48, 52, 46, 49, 55, 47, 54, 50, 48, 51, 47, 53, 49, 52, 47, 55, 51, 46, 49, 52, 50, 48],
                },
            ];
            categories = ['1am', '2am', '3am', '4am', '5am', '6am', '7am', '8am', '9am', '10am', '11am', '12pm', '1pm', '2pm', '3pm', '4pm', '5pm', '6pm', '7pm', '8pm', '9pm', '10pm', '11pm', '12am'];
            break;
        default:
            break;
    }

    let areaChartOptions = {
        series: data,
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
            categories: categories,
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
            size: 2,
            strokeColors: "#1b2635",
            strokeWidth: 2,
        },
        stroke: {
            curve: "smooth",
        },
        yaxis: {
            show: true,
            opposite: false,
            title: {
                text: "Meat Quantities in Kg",
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