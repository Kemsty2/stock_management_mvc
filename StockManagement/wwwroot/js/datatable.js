(function ($){
    "use strict";
    try{
        $(document).ready(function() {
            var table = $('#my-table').DataTable({                    
                "ajax": "arrays.json", 
                dom: '<"rs-select2--light rs-select2--md">frtip',                               
                order: [[ 3, "desc" ]],
                columns: [                    
                    { data: "nom" },
                    { data: "description" },
                    { data: "statut" },
                    { data: "createdAt" },
                    { data: "createdBy", render: $.fn.dataTable.render.number( ',', '.', 0, '$' ) },
                    {
                        data: null,                        
                        defaultContent: 
                        `<div class="table-data-feature">
                            <button
                            class="item btn"
                            data-toggle="tooltip"
                            data-placement="top"
                            title="Désctiver"
                            name="desactiver"                          
                            >
                            <i class="fa fa-power-off text-danger"></i>
                            </button>
                            <button
                            class="item btn"
                            data-toggle="tooltip"
                            data-placement="top"
                            name="modifier"
                            title="Modifier"
                            >
                            <i class="zmdi zmdi-edit"></i>
                            </button>
                            <button
                            class="item btn"
                            data-toggle="tooltip"
                            data-placement="top"
                            title="Supprimer"
                            name="supprimer"
                            >
                            <i class="zmdi zmdi-delete text-danger"></i>
                            </button>                    
                        </div>`
                    }
                ]
            });

            $('#my-table tbody').on( 'click', 'button', function () {
                var data = table.row($(this).parents('tr')).data();
                console.log(this);
                console.log(data);
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

            $(".js-select2[name='property']").on('change', function(e){
                e.preventDefault();
                
                console.log(e.target.value);

                table.page.len(e.target.value).draw();
            });

            $(".js-select2[name='property']").select2({
                placeholder: 'Select an option'
            });

            $('.au-btn-filter').on("click", function(){
                $('.collapse').collapse('toggle');
            });

            $.fn.dataTable.ext.search.push(
                function (settings, data, dataIndex) {
                    var min = $('#start-date').datepicker("getDate");
                    var max = $('#end-date').datepicker("getDate");
                    var startDate = new Date(data[3]);
                    if (min == null && max == null) { return true; }
                    if (min == null && startDate <= max) { return true;}
                    if(max == null && startDate >= min) {return true;}
                    if (startDate <= max && startDate >= min) { return true; }
                    return false;
                }
            );

            $("#start-date").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
            $("#end-date").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });            

            // Event listener to the two range filtering inputs to redraw on input
            $('#start-date, #end-date').change(function () {
                table.draw();
            });

            $('#clear').on('click', function(){
                $('#start-date, #end-date').val('');
                
                $("input[aria-controls='my-table']").val('');

                table.draw();
            });


        });
    }catch(e){
        console.error(e);
    }
})(jQuery);