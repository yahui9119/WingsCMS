var Lock = function () {

    return {
        //main function to initiate the module
        init: function () {

             $.backstretch([
		        "Content/img/bg/1.jpg",
		        "Content/img/bg/2.jpg",
		        "Content/img/bg/3.jpg",
		        "Content/img/bg/4.jpg"
		        ], {
		          fade: 1000,
		          duration: 8000
		      });
        }

    };

}();