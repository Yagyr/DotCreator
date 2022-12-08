let points = [];

function DrawContainer() {
    $.ajax({
        type: 'GET',
        url: '/Point/GetPoints',
        success: function (newPoints) {
            points = newPoints;
            DrawPoints();
        },
        error: function () {
            alert('Data not found');
        }
    });
}

function DeletePoint(pointId) {
    $.ajax({
        type: "POST",
        url: "/Point/DeletePoint",
        data: {Id: pointId},
        success: function () {
            points = points.filter(function (obj) {
                return obj.id !== pointId;
            });

            DrawPoints();
        },
        error: function () {
            alert('Failed to delete point');
        }
    })
}

function AddRandomPoint() {
    $.ajax({
        type: "POST",
        url: "/Point/AddRandomPoint",
        success: function (point) {
            points.push(point);
            DrawPoints();
        },
    })
}

function DrawPoints() {
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
    for (var i = 0; i < points.length; i++) {
        var group = new Konva.Group();
        var circle = new Konva.Circle({
            //Задаем координаты
            x: points[i].xPos,
            y: points[i].yPos,
            //Задаем радиус
            radius: points[i].radius,
            //Задаем цвет
            fill: points[i].color,
            //задаем id
            id: points[i].id,
        })
        //Добавляем все точки в группу
        group.add(circle)

        //Вычисляем позицию по y для комментариев
        var startPositionY = points[i].yPos + points[i].radius + 5;

        for (var k = 0; k < points[i].comments.length; k++) {
            let text = new Konva.Text({
                text: points[i].comments[k].text,
                fontFamily: 'cursive',
                fontSize: 20,
                padding: 5,
                fill: 'Green',
                id: points[i].id,
            });

            //Вычисляем позицию по x для комментариев 
            let startPositionX = points[i].xPos - text.width() / 2;
            var label = new Konva.Label({
                x: startPositionX,
                y: startPositionY,
            });
            
            //Делаем, чтобы комментарии располагались друг под другом
            startPositionY += 30;

            //Добавляем тэг
            label.add(
                new Konva.Tag({
                    fill: points[i].comments[k].backgroundColor,
                    stroke: "Grey",
                    opacity: 0.3,
                    id: points[i].id,
                })
            );

            //Добавляем текст
            label.add(
                text
            );

            //Добавляем комментарии в группу
            group.add(label)
        }
        
        //Добавляем группу в слой
        layer.add(group)
        
        //Удаление точки по двойному клику
        circle.on('dblclick', function (e) {
            var pointId = e.currentTarget.attrs.id;
            DeletePoint(pointId);
        })
    }

    let addRandomPointButton = new Konva.Label({
        x: 20,
        y: 20,
        opacity: 0.75
    });
    layer.add(addRandomPointButton);

    addRandomPointButton.add(new Konva.Tag({
        fill: 'black',
        lineJoin: 'round',
        shadowColor: 'black',
        shadowBlur: 10,
        shadowOffset: 10,
        shadowOpacity: 0.5
    }));

    addRandomPointButton.add(new Konva.Text({
        text: 'Add random point',
        fontFamily: 'Calibri',
        fontSize: 18,
        padding: 5,
        fill: 'white'
    }));

    addRandomPointButton.on('click', () => {
        AddRandomPoint();
    })

    //Добавляем слой в сцену
    stage.add(layer)
}
