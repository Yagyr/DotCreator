function DrawContainer() {
    $.ajax({
        type: 'GET',
        url: '/Point/GetPoints',
        success: function (point) {
            DrawPoint(point);
        },
        error: function () {
            alert('Data not found');
        }
    });
}
function DrawPoint(point){
    var width = window.innerWidth;
    var height = window.innerHeight;

    //Создаем сцену 
    var stage = new Konva.Stage({
        container: 'canvas',
        width: width,
        height: height
    });
    
    //Создаем слой
    var layer = new Konva.Layer();
    for (var i = 0; i < point.length; i++) {
        var group = new Konva.Group();
        var circle = new Konva.Circle({
            //Задаем координаты
            x: point[i].xPos, 
            y: point[i].yPos, 
            //Задаем радиус
            radius: point[i].radius,
            //Задаем цвет
            fill: point[i].color, 
            //задаем id
            id: point[i].id,
        })
        //Добавляем все точки в группу
        group.add(circle)
        
        //Вычисляем позицию по y для комментариев
        var startPositionY = point[i].yPos + point[i].radius + 5;

        for (var k = 0; k < point[i].comments.length; k++){
            //Вычисляем позицию по x для комментариев 
            var startPositionX = point[i].xPos - (point[i].comments[k].text.length * 6.1);
            var label = new Konva.Label({
                x: startPositionX,
                y: startPositionY,
            });
            //Делаем, чтобы комментарии располагались друг под другом
            startPositionY += 30;

            //Добавляем стиль тэга
            label.add(
                new Konva.Tag({
                    fill: point[i].comments[k].backgroundColor,
                    stroke: "Grey",
                    opacity: 0.3,
                    id: point[i].id,
                })
            );
            
            //Добавляем стиль текста
            label.add(
                new Konva.Text({
                    text: point[i].comments[k].text,
                    fontFamily: 'cursive',
                    fontSize: 20,
                    padding: 5,
                    fill: 'Green',
                    id: point[i].id,
                })
            );
            //Добавляем комментарии в группу
            group.add(label)
        }
        //Добавляем группу в слой
        layer.add(group)
        //Удаление точки по двойному клику
        circle.on('dblclick', function (e) {
            var idDelete = e.currentTarget.attrs.id;
            $.ajax({
                url: "/Point/DeletePoint",
                type: "post",
                datatype: "text",
                data: {Id: idDelete},
                success: function (response) {
                    if (response) {
                    //ToDo визуальное удаление элементов
                    }
                    else {
                        alert("Idi zanovo razbiraisya!")
                    }
                }
            })
        })
    }
    //Добавляем слой в сцену
    stage.add(layer)
}
