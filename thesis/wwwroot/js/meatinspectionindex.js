
$(document).ready(function () {

    // Check if tableOne is initially empty
    var isTableOneEmpty = $('#tableOne tbody tr').length === 0;

    if (isTableOneEmpty) {
        $('#tableni').hide(); // Hide tableni if tableOne is empty
        $('#tableThree').hide();
        $('#tableTwo').hide();
        $('#tableFour').hide();
        $('#tableFive').hide();
        $('#tableSix').hide(); // Hide tableSix if tableOne is empty
        // Add logic here to hide related rows in tableni and tableSix
    }

    var tables = $('#tableOne').DataTable({
        paging: true,
        lengthChange: true,
        pageLength: 30,
        lengthMenu: [30, 50, 100],
        searching: true,
        ordering: true,
        responsive: true,
    });

    var currentDate = new Date();
    currentDate.setDate(1); // Set the day to the 1st of the current month

    // Format the date as 'YYYY-MM' (year and month)
    var currentMonth = currentDate.toISOString().slice(0, 7);

    // Set the value of the date input field to the current month
    $('#dateFilter').val(currentMonth);

    // Add an event listener to the date input field
    tables.column(0).search(currentMonth).draw();
    // Add an event listener to the date input field
    $('#dateFilter').on('change', function () {
        tables.column(0).search(this.value).draw();
        updateFilter();
        tableTwo();
        tableThree();
        tableFour();
        tableFive();
        tableSix();
    });


    $('#meatEstablishmentFilter').on('change', function () {
        var selectedTexts = $(this).find('option:selected').text();
        tables.column(4).search(selectedTexts).draw();
        updateFilter();
        tableTwo();
        tableThree();
        tableFour();
        tableFive();
        tableSix();
    });

    $('#species').on('change', function () {
        var selectedText = $(this).find('option:selected').text();
        tables.column(1).search(selectedText).draw();
        updateFilter();
        tableTwo();
        tableThree();
        tableFour();
        tableFive();
        tableSix();
    });

    // Other code and event listeners...
});
function updateFilter() {
    var receivingReportIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableOne tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(7)').text();
        receivingReportIds.push(id);
    });

    // Loop through the rows in tableni and show/hide based on the filter
    $('#tableni tbody tr').each(function () {
        var receivingReportId = $(this).find('td:last').text();

        if (receivingReportIds.includes(receivingReportId)) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}


function tableTwo() {
    var meatInspectionIds = [];

    // Loop through the visible rows in tableOne and store their IDs
    $('#tableni tbody tr:visible').each(function () {
        var id = $(this).find('td:eq(5)').text();
        meatInspectionIds.push(id);
    });



    $('#tableTwo tbody tr').each(function () {
        var meatInspectionId = $(this).find('td:eq(7)').text(); // Get MeatInspectionId from the 8th column

        if (meatInspectionIds.includes(meatInspectionId)) {
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

function toggleTableVisibility() {
    var container = document.getElementById("tableContainer");
    if (container.style.visibility === "hidden" || container.style.visibility === "") {
        container.style.visibility = "visible";
        container.style.width = "auto"; // Restore width to auto
        container.style.height = "auto"; // Restore height to auto
    } else {
        container.style.visibility = "hidden";
        container.style.width = "0"; // Set width to 0 when hidden
        container.style.height = "0"; // Set height to 0 when hidden
    }
}

function filterhide() {
    var filterDiv = document.getElementById("filter");
    if (filterDiv.style.display === "none") {
        filterDiv.style.display = "block"; // Show the div if it's currently hidden
    } else {
        filterDiv.style.display = "none"; // Hide the div if it's currently visible
    }
}

function filterbutton() {
    toggleTableVisibility();
    filterhide();
    onemerge();
    twomerge();
    threemerge();
    fourmerge();
    fivemerge();

}


//species

function getTableOneData() {
    var data = {
        nameOfMeatEstablishment: '',
        address: '',
        ltoNumber: ''
    };

    // Find the specific table row elements that contain the data you want
    var nameRow = $('#tableOne tbody tr:nth-child(1)');
    var addressRow = $('#tableOne tbody tr:nth-child(1)');
    var ltoNumberRow = $('#tableOne tbody tr:nth-child(1)');

    // Extract the data from the table rows
    data.nameOfMeatEstablishment = nameRow.find('td:nth-child(5)').text();
    data.address = addressRow.find('td:nth-child(7)').text();
    data.ltoNumber = ltoNumberRow.find('td:nth-child(6)').text();

    return data;
}
function download() {
    // Initialize the allData array to empty before appending data from each table
    var allData = [];
    var tableOneData = getTableOneData();
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
    allData.push(['MONTHLY MEAT INSPECTION REPORTS', '', '', '', '', '', '']);

    var month = $('#dateFilter').val();
    var species = $('#species').val();

    allData.push(['Region:', '', '', '', '', '', '']);
    allData.push(['Name of Meat Establishment:', tableOneData.nameOfMeatEstablishment, '', '', '', '', '']);
    allData.push(['Address:', tableOneData.address, '', '', '', '', '']);
    allData.push(['License to Operate (LTO) No:', tableOneData.ltoNumber, '', '', '', '', '']);

    allData.push(['Month:', month, '', '', '', '', '']);
    allData.push(['Species:', species, '', '', '', '', '']);
    // Combine data from all tables into the allData array
    allData.push('', '');
    allData.push(['I. Antemortem Inspection', '', '', '', '', '', '']); // Name for Antemortem Inspection
    allData = allData.concat(getVisibleTableData('tableOne', 'A. Receiving of Food Animals for Slaughter'));
    allData = allData.concat(getVisibleTableData('tableTwo', 'B. Conduct of Antemortem Inspection'));
    allData = allData.concat(getVisibleTableData('tableThree', 'C. Passed for Slaughter'));
    allData = allData.concat(getVisibleTableData('tableFour', 'II. Postmortem Inspection'));
    allData = allData.concat(getVisibleTableData('tableFive', 'III. Total Number of Food Animals Fit for Human Consumption'));
    allData = allData.concat(getVisibleTableData('tableSix', 'IV. Summary and Distribution of Meat Inspection Certificate'));

    allData.push('', '')
    allData.push(['Prepared by:', '', '', '', '', '', '']);
    allData.push(['', 'Meat Inspection Officer', '', '', '', '', '']);
    allData.push('', '');
    allData.push(['Conforme:', '', '', '', '', '', '']);
    allData.push(['', 'Authorized Meat Establishment Representative', '', '', '', '', '']);
    allData.push('', '');
    allData.push(['Verified by:', '', '', '', '', '', '']);
    allData.push(['', 'POSMS HEAD', '', '', '', '', '']);
    // Create a new workbook with a single sheet
    var ws = XLSX.utils.aoa_to_sheet(allData);

    var columnWidths = [190, 190, 190, 190, 190, 190, 190, 190];

    // Apply column widths to the worksheet
    ws['!cols'] = columnWidths.map(function (width) {
        return { wpx: width };
    });



    var mergeTitleRange = { s: { r: 0, c: 0 }, e: { r: 0, c: 7 } };
    if (!ws['!merges']) ws['!merges'] = [];
    ws['!merges'].push(mergeTitleRange);

    var mergeTitleRange = { s: { r: 1, c: 0 }, e: { r: 1, c: 7 } };
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

function onemerge() {
    // Initialize an object to store the sums
    updateFilter();
    tableTwo();
    tableThree();
    tableFour();
    tableFive();
    tableSix();
    var sums = {};

    // Loop through each row in the table
    $('#tableOne tbody tr').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var origin = $(this).find('td:eq(3)').text();
        var monthYear = $(this).find('td:eq(0)').text(); // Get the "Time" value (month and year)
        var heads = parseInt($(this).find('td:eq(2)').text());

        // Create a unique key based on species, origin, and monthYear
        var key = species + origin + monthYear;

        // Update the sum for the key
        sums[key] = (sums[key] || 0) + heads;
    });

    // Update the table with the sums
    $('#tableOne tbody tr').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var origin = $(this).find('td:eq(3)').text();
        var monthYear = $(this).find('td:eq(0)').text(); // Get the "Time" value (month and year)

        // Create a unique key based on species, origin, and monthYear
        var key = species + origin + monthYear;

        // Set the sum in the corresponding row
        $(this).find('td:eq(2)').text(sums[key]);
    });
    tableOneduplicatefilter();
}

function tableOneduplicatefilter() {

    $('#tableOne tbody tr').each(function () {
        var currentRow = $(this);
        var species = currentRow.find('td:eq(1)').text(); // Index 2 corresponds to the "Species" column
        var origin = currentRow.find('td:eq(3)').text(); // Index 4 corresponds to the "Origin" column
        var time = currentRow.find('td:eq(0)').text(); // Index 0 corresponds to the "Time" column
        var noofheads = currentRow.find('td:eq(2)').text(); // Index 3 corresponds to the "NoOfHeads" column

        // Check if there are other rows with the same values within the same table
        var duplicateRows = $('#tableOne tbody tr:visible').filter(function () {
            return (
                $(this).find('td:eq(1)').text() === species &&
                $(this).find('td:eq(3)').text() === origin &&
                $(this).find('td:eq(0)').text() === time &&
                $(this).find('td:eq(2)').text() === noofheads
            );
        });

        if (duplicateRows.length > 1) {
            // Hide all but the first row with the same values
            duplicateRows.not(':first').hide();
        }
    });
}


function twomerge() {
    var sums = {};

    // Loop through each row in the table
    $('#tableTwo tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var cause = $(this).find('td:eq(5)').text();
        var heads = parseInt($(this).find('td:eq(3)').text());
        var weight = parseInt($(this).find('td:eq(4)').text());

        // Create a unique key based on species, cause, and weight
        var key = species + cause;

        // Update the sum for the key
        sums[key] = {
            heads: (sums[key] && sums[key].heads || 0) + heads,
            weight: (sums[key] && sums[key].weight || 0) + weight
        };
    });

    // Update the table with the sums
    $('#tableTwo tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var cause = $(this).find('td:eq(5)').text();

        // Create a unique key based on species and cause
        var key = species + cause;

        // Set the sum in the corresponding row
        $(this).find('td:eq(3)').text(sums[key].heads);
        $(this).find('td:eq(4)').text(sums[key].weight);
    });

    tableTwoduplicatefilter();
}

function tableTwoduplicatefilter() {
    $('#tableTwo tbody tr').each(function () {
        var currentRow = $(this);
        var species = currentRow.find('td:eq(1)').text(); // Index 2 corresponds to the "Species" column
        var cause = currentRow.find('td:eq(5)').text(); // Index 4 corresponds to the "Cause" column

        // Check if there are other rows with the same values within the same table
        var duplicateRows = $('#tableTwo tbody tr:visible').filter(function () {
            return (
                $(this).find('td:eq(1)').text() === species &&
                $(this).find('td:eq(5)').text() === cause
            );
        });

        if (duplicateRows.length > 1) {
            // Hide all but the first row with the same values
            duplicateRows.not(':first').hide();
        }
    });
}


function threemerge() {
    var sums = {};

    // Loop through each row in tableThree
    $('#tableThree tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var noofheads = parseInt($(this).find('td:eq(2)').text());
        var weight = parseInt($(this).find('td:eq(3)').text());

        // Create a unique key based on species
        var key = species;

        // Update the sum for the key
        sums[key] = {
            noofheads: (sums[key] && sums[key].noofheads || 0) + noofheads,
            weight: (sums[key] && sums[key].weight || 0) + weight
        };
    });

    // Update the tableThree with the sums
    $('#tableThree tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();

        // Create a unique key based on species
        var key = species;

        // Set the sum in the corresponding row
        $(this).find('td:eq(2)').text(sums[key].noofheads);
        $(this).find('td:eq(3)').text(sums[key].weight);
    });
    tableThreeduplicatefilter();
}

function tableThreeduplicatefilter() {
    $('#tableThree tbody tr').each(function () {
        var currentRow = $(this);
        var species = currentRow.find('td:eq(1)').text(); // Index 1 corresponds to the "Species of Food Animal" column
        var noofheads = currentRow.find('td:eq(2)').text(); // Index 2 corresponds to the "No. of heads" column
        var weight = currentRow.find('td:eq(3)').text(); // Index 3 corresponds to the "Weight" column

        // Check if there are other rows with the same values within the same table
        var duplicateRows = $('#tableThree tbody tr:visible').filter(function () {
            return (
                $(this).find('td:eq(1)').text() === species &&
                $(this).find('td:eq(2)').text() === noofheads &&
                $(this).find('td:eq(3)').text() === weight
            );
        });

        if (duplicateRows.length > 1) {
            // Hide all but the first row with the same values
            duplicateRows.not(':first').hide();
        }
    });
}


function fourmerge() {
    var sums = {};

    // Loop through each row in tableThree
    $('#tableFour tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var cause = $(this).find('td:eq(3)').text();
        var animalpart = $(this).find('td:eq(2)').text();
        var noofheads = parseInt($(this).find('td:eq(4)').text());
        var weight = parseInt($(this).find('td:eq(5)').text());

        // Create a unique key based on species
        var key = species + cause + animalpart;

        // Update the sum for the key
        sums[key] = {
            noofheads: (sums[key] && sums[key].noofheads || 0) + noofheads,
            weight: (sums[key] && sums[key].weight || 0) + weight
        };
    });

    // Update the tableThree with the sums
    $('#tableFour tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(1)').text();
        var cause = $(this).find('td:eq(3)').text();
        var animalpart = $(this).find('td:eq(2)').text();

        // Create a unique key based on species
        var key = species + cause + animalpart;

        // Set the sum in the corresponding row
        $(this).find('td:eq(4)').text(sums[key].noofheads);
        $(this).find('td:eq(5)').text(sums[key].weight);
    });
    tableFourduplicatefilter();
}

function tableFourduplicatefilter() {
    $('#tableFour tbody tr').each(function () {
        var currentRow = $(this);
        var species = currentRow.find('td:eq(1)').text(); // Index 1 corresponds to the "Species of Food Animal" column
        var cause = $(this).find('td:eq(3)').text();
        var animalpart = $(this).find('td:eq(2)').text();
        var noofheads = currentRow.find('td:eq(4)').text(); // Index 2 corresponds to the "No. of heads" column
        var weight = currentRow.find('td:eq(5)').text(); // Index 3 corresponds to the "Weight" column

        // Check if there are other rows with the same values within the same table
        var duplicateRows = $('#tableFour tbody tr:visible').filter(function () {
            return (
                $(this).find('td:eq(1)').text() === species &&
                $(this).find('td:eq(3)').text() === cause &&
                $(this).find('td:eq(2)').text() === animalpart &&
                $(this).find('td:eq(4)').text() === noofheads &&
                $(this).find('td:eq(5)').text() === weight
            );
        });

        if (duplicateRows.length > 1) {
            // Hide all but the first row with the same values
            duplicateRows.not(':first').hide();
        }
    });
}


function fivemerge() {
    var sums = {};

    // Loop through each row in tableThree
    $('#tableFive tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(0)').text();
        var noofanimals = parseInt($(this).find('td:eq(1)').text());
        var weight = parseInt($(this).find('td:eq(2)').text());

        // Create a unique key based on species
        var key = species;

        // Update the sum for the key
        sums[key] = {
            noofanimals: (sums[key] && sums[key].noofanimals || 0) + noofanimals,
            weight: (sums[key] && sums[key].weight || 0) + weight
        };
    });

    // Update the tableThree with the sums
    $('#tableFive tbody tr:visible').each(function () {
        var species = $(this).find('td:eq(0)').text();

        // Create a unique key based on species
        var key = species;

        // Set the sum in the corresponding row
        $(this).find('td:eq(1)').text(sums[key].noofanimals);
        $(this).find('td:eq(2)').text(sums[key].weight);
    });
    tableFiveduplicatefilter();
}

function tableFiveduplicatefilter() {
    $('#tableFive tbody tr').each(function () {
        var currentRow = $(this);
        var species = currentRow.find('td:eq(0)').text(); // Index 1 corresponds to the "Species of Food Animal" column
        var noofanimals = currentRow.find('td:eq(1)').text(); // Index 2 corresponds to the "No. of heads" column
        var weight = currentRow.find('td:eq(2)').text(); // Index 3 corresponds to the "Weight" column

        // Check if there are other rows with the same values within the same table
        var duplicateRows = $('#tableFive tbody tr:visible').filter(function () {
            return (
                $(this).find('td:eq(0)').text() === species &&
                $(this).find('td:eq(1)').text() === noofanimals &&
                $(this).find('td:eq(2)').text() === weight
            );
        });

        if (duplicateRows.length > 1) {
            // Hide all but the first row with the same values
            duplicateRows.not(':first').hide();
        }
    });
}
