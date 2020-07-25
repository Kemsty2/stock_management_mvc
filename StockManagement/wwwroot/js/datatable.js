(function ($) {
    "use strict";
    try {
        $(document).ready(function () {
            moment.locale("fr");

            var table = $("#my-table").DataTable({
                serverSide: true,                
                pageLength: 10,
                order: [[3, "desc"]],
                language: {
                    zeroRecords: "Aucune Donnée",
                    loadingRecords: "Chargement des données",                    
                },
                columnDefs:
                    [{
                        "targets": [8],
                        "visible": false,
                        "searchable": false
                    }], 
                ajax: function (datasample, callback) {
                    console.log({
                        startDate: $("#start-date").val(),
                        endDate: $("#end-date").val()
                    })
                    $.ajax({
                        url,
                        data: {
                            ...datasample,
                            openDate: $("#start-date").val(),
                            closeDate: $("#end-date").val()
                        },                        
                        dataType: "json",
                        method: "GET",
                        beforeSend: function () {
                            $("#loader").removeClass("hidden")
                        },
                        success: function (result) {
                            console.log(result);

                            const tab = [];

                            result.data.forEach((el, idx) => {
                                const createdAt = moment(el.CreatedAt).format("dddd, MMMM Do YYYY, h:mm");
                                const updatedAt = moment(el.UpdatedAt).format("dddd, MMMM Do YYYY, h:mm");

                                tab.push({                                    
                                    id: idx + 1,
                                    label: el.Label,
                                    description: el.Description,
                                    createdAt,
                                    createdBy : el.CreatedBy,
                                    updatedAt,
                                    updatedBy: el.UpdatedBy,
                                    elementId: el.Id
                                });
                            });

                            callback({
                                draw: result.draw,
                                data: tab,
                                recordsTotal: result.recordsTotal,
                                recordsFiltered: result.recordsFiltered
                            });
                        },
                        error: function (err) {                            
                            console.log(err);

                            callback({
                                data: [],
                                recordsTotal: 0,
                                recordsFiltered: 0
                            });
                        },
                        complete: function () {
                            $("#loader").addClass("hidden");
                        }
                    });
                },
                dom: '<"rs-select2--light rs-select2--md">Bfrtip',
                buttons: [
                    "csv", "excel", "pdf"
                ],
                columns: [
                    ...baseColumns,                    
                ]
            });

            $("#my-table tbody").on("click", "button", function (e) {
                e.preventDefault();
                const name = e.currentTarget.name;

                const data = table.row($(this).parents("tr")).data();
                console.log({ data, name });

                switch (name) {
                    case "details":
                        document.location.href = `${detPath}/${data.elementId}`;
                        break;

                    case "modifier":
                        document.location.href = `${modPath}/${data.elementId}`;
                        break;

                    case "supprimer":
                        $.confirm({
                            escapeKey: true,
                            backgroundDismiss: false,
                            draggable: true,
                            closeIcon: true,
                            type: "red",
                            typeAnimated: true,
                            title: deleteTitle,
                            content: deleteMessage,
                            autoClose: "cancelAction|8000",
                            buttons: {
                                supprimer: {
                                    text: "Supprimer",
                                    btnClass: "btn-red",
                                    action: function () {
                                        document.location.href = `${delPath}/${data.elementId}`;
                                    },
                                },
                                annuler: {
                                    text: "Annuler",
                                    action: function () {
                                        return;
                                    }
                                },
                            }
                        });
                        break;
                    default:
                        return;
                }
            });

            $(".rs-select2--light").html(`
                <select class="js-select2" name="property">
                    <option value="10">10</option>
                    <option value="25">25</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                </select>
                <div class="dropDownSelect2"></div>
            `);

            $(".js-select2[name='property']").on("change", function (e) {
                e.preventDefault();

                console.log(e.target.value);

                table.page.len(e.target.value).draw();
            });

            $(".js-select2[name='property']").select2({
                placeholder: "Select an option"
            });

            $(".au-btn-filter").on("click", function () {
                $(".collapse").collapse("toggle");
            });

            $.fn.dataTable.ext.search.push(
                function (settings, data, dataIndex) {
                    
                    const min = $("#start-date").datepicker("getDate");
                    const max = $("#end-date").datepicker("getDate");
                    const startDate = new Date(data[3]);

                    if (min == null && max == null) { return true; }
                    if (min == null && startDate <= max) { return true; }
                    if (max == null && startDate >= min) { return true; }
                    if (startDate <= max && startDate >= min) { return true; }
                    return false;
                }
            );

            $("#start-date").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
            $("#end-date").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });

            // Event listener to the two range filtering inputs to redraw on input
            $("#start-date, #end-date").change(function () {
                table.draw();
            });

            $("#clear").on("click", function () {
                $("#start-date, #end-date").val("");

                $("input[aria-controls='my-table']").val("");

                table.draw();
            });
        });
    } catch (e) {
        console.error(e);
    }
})(jQuery);