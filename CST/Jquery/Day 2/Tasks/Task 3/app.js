$(function () {
        $('#rab').draggable();
        $('#bh').droppable({
            drop: function (event, ui){
                $(ui.draggable).hide('fade', 500)
            }
        });


    }
);