(function ($) {
  "use strict";

  try {
    $(document).ready(function () {

      $("#dateRetrait").datepicker({        
        changeMonth: true,
        changeYear: true,
      });      
    });

  } catch (e) {
    console.log(e);
  }
})(jQuery);
