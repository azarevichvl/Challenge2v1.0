fetch("Home/GetPointsJson").then(function (response) {
    return response.json();
}).then(function (points) {

    var chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,  
        title:{
            text: "Porabolic Function"
        },
        data: [{            
            type: "spline",
            dataPoints: points
        }]
    });
    chart.render();
    console.log(points);
})


