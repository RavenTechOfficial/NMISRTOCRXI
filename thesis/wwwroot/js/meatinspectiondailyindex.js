
$(document).ready(function () {
    updateFilter();
    tableTwo();
    tableThree();
    tableFour();
    tableFive();
    tableSix();
});

function updateFilter() {
    var selectedReportId = $("#ReceivingReportId").val(); // Get the selected ReceivingReportId from the form

    // Loop through the rows in tableOne and show/hide based on the selected ReportId
    $('#tableOne tbody tr').each(function () {
        var receivingReportId = $(this).find('td:last').text();

        if (receivingReportId === selectedReportId) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}


function tableTwo() {

    var selectedId = $("#Id").val();

    $('#tableTwo tbody tr').each(function () {
        var meatInspectionId = $(this).find('td:eq(7)').text(); // Get MeatInspectionId from the 8th column

        if (meatInspectionId === selectedId) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

function tableThree() {
    var ConductOfInpsectionIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableTwo tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(6)').text();
        ConductOfInpsectionIds.push(id);
    });



    $('#tableThree tbody tr').each(function () {
        var ConductOfInpsectionId = $(this).find('td:eq(5)').text(); // Get MeatInspectionId from the 8th column

        if (ConductOfInpsectionIds.includes(ConductOfInpsectionId)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}
function tableFour() {
    var passedSlaughterIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableThree tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(4)').text();
        passedSlaughterIds.push(id);
    });


    $('#tableFour tbody tr').each(function () {
        var passedSlaughterId = $(this).find('td:eq(7)').text(); // Get MeatInspectionId from the 8th column

        if (passedSlaughterIds.includes(passedSlaughterId)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

function tableFive() {
    var PostmortemIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableFour tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(6)').text();
        PostmortemIds.push(id);
    });


    $('#tableFive tbody tr').each(function () {
        var PostmortemId = $(this).find('td:eq(4)').text(); // Get MeatInspectionId from the 8th column

        if (PostmortemIds.includes(PostmortemId)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

function tableSix() {
    var totalfitIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableFive tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(3)').text();
        totalfitIds.push(id);
    });


    $('#tableSix tbody tr').each(function () {
        var totalfitId = $(this).find('td:eq(8)').text(); // Get MeatInspectionId from the 8th column

        if (totalfitIds.includes(totalfitId)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}


//date
function filterDataDate() {
    var startDate = new Date(document.getElementById("startdate").value);
    startDate.setHours(0, 0, 0, 0); // Set time to start of the day
    var endDate = new Date(document.getElementById("enddate").value);
    endDate.setHours(23, 59, 59, 999); // Set time to end of the day

    var rows = document.querySelectorAll("#tableOne tbody tr");

    rows.forEach(function (row) {
        var dateCell = row.querySelector("td:first-child");
        var dateString = dateCell.textContent;
        var rowDate = new Date(dateString.split(" ")[0]);

        if (startDate && endDate) {
            if (rowDate >= startDate && rowDate <= endDate) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        }
    });
    updateFilter();
    tableTwo();
    tableThree();
    tableFour();
    tableFive();
    tableSix();
}
//species

function filterDataSpecies() {
    var selectedSpecies = document.getElementById("species").value;
    var table = document.getElementById("tableOne");
    var rows = table.getElementsByTagName("tr");

    for (var i = 1; i < rows.length; i++) { // Start from 1 to skip the header row
        var speciesCell = rows[i].cells[2]; // Assuming species is in the third column (index 2)

        if (selectedSpecies === "All" || speciesCell.innerHTML === selectedSpecies) {
            rows[i].style.display = "";
        } else {
            rows[i].style.display = "none";
        }
    }
    updateFilter();
    tableTwo();
    tableThree();
    tableFour();
    tableFive();
    tableSix();
}

function download() {
    // Initialize the allData array to empty before appending data from each table
    var allData = [];

    // Function to get visible rows and column titles from a table
    function getVisibleTableData(tableId, tableTitle) {
        var data = [];
        var columnTitles = [];
        var excludedColumns = [];

        // Get the column titles from the table's header row and check for aria-hidden
        $('#' + tableId + ' thead tr th').each(function (index) {
            var isHidden = $(this).attr('aria-hidden');
            if (!isHidden || isHidden !== 'true') {
                columnTitles.push($(this).text());
            } else {
                excludedColumns.push(index); // Keep track of excluded columns
            }
        });

        // Combine the title and column titles into a single cell
        var titleCell = [tableTitle, '', '', '', '', '', ''].join(' ');
        data.push([titleCell]); // Title row
        data.push(columnTitles); // Column titles row

        $('#' + tableId + ' tbody tr:visible').each(function () {
            var row = [];
            $(this).find('td').each(function (index) {
                // Check if the column should be included based on the exclusion list
                if (excludedColumns.indexOf(index) === -1) {
                    row.push($(this).text());
                }
            });
            data.push(row);
        });

        data.push(['']); // Empty row after data

        return data;
    }

    // Add data from DisplayNameFor and DisplayFor elements
    allData.push('');
    allData.push(['DAILY MEAT INSPECTION REPORT', '', '', '', '', '', '']);

    allData.push(['Region:', '', '', '', '', '', '']);
    allData.push(['Name of Meat Establishment:', '@Model.MeatEstablishment', '', '', '', '', '']);
    allData.push(['Address:', '@Model.Address', '', '', '', '', '']);
    allData.push(['License to Operate (LTO) No:', '@Model.LicenseToOperateNumber', '', '', '', '', '']);
    allData.push(['Date Inspected:', '@Model.RepDate', '', '', '', '', '']);

    // Combine data from all tables into the allData array
    allData.push('', '');
    allData.push(['I. Antemortem Inspection', '', '', '', '', '', '']); // Name for Antemortem Inspection
    allData = allData.concat(getVisibleTableData('tableOne', 'A. Receiving of Food Animals for Slaughter'));
    allData = allData.concat(getVisibleTableData('tableTwo', 'B. Conduct of Antemortem Inspection'));
    allData = allData.concat(getVisibleTableData('tableThree', 'C. Passed for Slaughter'));
    allData = allData.concat(getVisibleTableData('tableFour', 'II. Postmortem Inspection'));
    allData = allData.concat(getVisibleTableData('tableFive', 'III. Total Number of Food Animals Fit for Human Consumption'));
    allData = allData.concat(getVisibleTableData('tableSix', 'IV. Summary and Distribution of Meat Inspection Certificate'));
    allData.push('', '', '');


    allData.push(['Prepared by:', '', '', '', '', '', '']);
    allData.push(['', 'Meat Inspection Officer', '', '', '', '', '']);
    allData.push('', '');
    allData.push(['Conforme:', '', '', '', '', '', '']);
    allData.push(['', 'Authorized Meat Establishment Representative', '', '', '', '', '']);
    allData.push('', '');
    allData.push(['Verified by:', '', '', '', '', '', '']);
    allData.push(['', 'POSMS HEAD', '', '', '', '', '']);
    allData.push('', '');
    // Create a new workbook with a single sheet
    var ws = XLSX.utils.aoa_to_sheet(allData);

    var columnWidths = [190, 190, 190, 190, 190, 190, 190, 190];

    // Apply column widths to the worksheet
    ws['!cols'] = columnWidths.map(function (width) {
        return { wpx: width };
    });
    // Create a merged cell for "Antemortem Inspection"
    var mergeTitleRange = { s: { r: 0, c: 0 }, e: { r: 0, c: 6 } };
    if (!ws['!merges']) ws['!merges'] = [];
    ws['!merges'].push(mergeTitleRange);

    // Create a new workbook
    var wb = XLSX.utils.book_new();

    // Add the sheet to the workbook
    XLSX.utils.book_append_sheet(wb, ws, 'CombinedData');

    // Convert workbook to binary XLSX format
    var wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'binary' });

    // Save the file
    saveAs(new Blob([s2ab(wbout)], { type: 'application/octet-stream' }), 'data.xlsx');
}

// Utility function to convert binary string to ArrayBuffer
function s2ab(s) {
    var buf = new ArrayBuffer(s.length);
    var view = new Uint8Array(buf);
    for (var i = 0; i < s.length; i++) {
        view[i] = s.charCodeAt(i) & 0xFF;
    }
    return buf;
}