(function ($) {
  "use strict";

  try {
    $(document).ready(function () {

      $("#dateAchat").datepicker({        
        changeMonth: true,
        changeYear: true,
      });      
    });

  } catch (e) {
    console.log(e);
  }
})(jQuery);
