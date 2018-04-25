

    $.Loading = function(options) {

    var methods = {

            init : function(option) {
                if (options === true) {
                    helpers.start();
                } else {
                    helpers.stop();
                }
                return this;
            }
        }

        var helpers = {
        	start : function(){
        		if($('#full-loading').length == 0) {
        		    var loading = $("<div>").attr("id", "full-loading").addClass("full-loading");
        		    var wrapper = $("<div>").addClass("wrapper").appendTo(loading);
        		    var inner = $("<div>").addClass("sk-cube-grid").appendTo(wrapper);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-0-0.png").addClass("sk-cube sk-cube1").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-0-1.png").addClass("sk-cube sk-cube2").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-0-2.png").addClass("sk-cube sk-cube3").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-1-0.png").addClass("sk-cube sk-cube4").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-1-1.png").addClass("sk-cube sk-cube5").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-1-2.png").addClass("sk-cube sk-cube6").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-2-0.png").addClass("sk-cube sk-cube7").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-2-1.png").addClass("sk-cube sk-cube8").appendTo(inner);
        		    $("<img>").attr("src", "/Images/loading/bpormas [www.imagesplitter.net]-2-2.png").addClass("sk-cube sk-cube9").appendTo(inner);
        		    //$("<div>").attr("style", "text-align:center;font-size:14px;color:#303e48").html("Cargando datos").appendTo(inner);
        		    $(loading).appendTo("body");
                }
        	},
        	stop : function(){
        		if($('#full-loading').length != 0) {
                    $('#full-loading').remove();
                }
        	}
        }

       

        return methods.init.apply(this, arguments);
    }

