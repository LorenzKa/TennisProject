$(function () {
    function deletePerson(id){
        console.log('kevin ist dumm')
        $.ajax({
            url: 'https://localhost:5001/persons',
            method : 'DELETE',
            dataType: 'json'
        })
    }
    function createButtonsAndTables() {
        $('<button type="button" id="btn_Persons" class="btn btn-dark">Persons</button>').on('click', event => {
            createAndFillPersonTable();
        }).appendTo($('#buttons'))
        $('<button type="button" id="btn_Bookings" class="btn btn-dark">Bookings</button>').on('click', event => {
            createAndFillBookingsTable();
        }).appendTo($('#buttons'))
        $('<table class="table table-dark table-striped">')
            .append('<thead id="tableHead">')
            .append('<tbody id="tableCols">')
            .appendTo($('#tableDiv'));
    }
    function createAndFillPersonTable() {
        $('#tableHead').empty();
        $('#tableCols').empty();
        $("#addBooking").empty();
        createPerson();
        $('#tableHead')
            .append(`
        <tr><th scope="col">Nachname</th>
        <th scope="col">Vorname</th>
        <th scope="col">Alter</th>
        <th scope="col">#Reservierungen</th>
        <th scope="col">Delete</th></tr>`)
        console.log("createdTable");
        var deleteRow = function (link) {
            var row = link.parentNode.parentNode;
            var table = row.parentNode; 
            table.removeChild(row); 
        }
        $.getJSON('https://localhost:5001/persons').then(data => {
            data.forEach(async element => {
                var count = await getBookingsForId(element.id);
                $('<tr id=row' + element.id + ">")
                    .append('<th scope="row">' + element.firstname + '</th>')
                    .append('<td>' + element.lastname + '</td>')
                    .append('<td>' + element.age + '</td>')
                    .append('<td>' + count + '</td>')
                    .append('<td> <a href="javascript:void(0)" onclick="deletePerson(this);">Delete</td>')
                    .appendTo('#tableCols')
            });
        });
        
    }
    function getBookingsForId(id) {
        return new Promise((resolve) => {
            var count = 0;
            $.getJSON('https://localhost:5001/bookings/user/' + id).then(data2 => {
                count = Object.keys(data2).length;
                console.log(count);
                resolve(count);
            })
        })
    }
    function createAndFillBookingsTable() {
        $("#addBooking").empty();
        $('#tableHead').empty();
        $('#tableCols').empty();
        createBooking();
        $('#tableHead').append(`<tr id="tableHeadValues"><th scope="col">Hour</th></tr>'`)
        for (var i = 1; i <= 7; i++) {
            $('#tableHeadValues').append('<th scope="col">' + i + '</th>');
        }
        for (var x = 10; x <= 22; x++) {
            $('<tr id=row' + x + ">")
                .append('<th scope="row">' + x + '</th>')
                .append(`<td id="` + x + `1></td>`)
                .append('<td></td>')
                .append('<td></td>')
                .append('<td></td>')
                .append('<td></td>')
                .append('<td></td>')
                .append('<td></td>')
                .appendTo('#tableCols')


        }
        console.log("createdTable");
        //$('')
    }
    function createBooking(){
        $("#addBooking")
        .append('<select id="person"></select>')
        .append('<input id="week" type="number"></input>')
        .append('<input id="day" type="number"></input>')
        .append('<input id="hour" type="number"></input>')
        .append('<button type="button" id="btn_add" class="btn btn-dark">Add</button>')
        $('#btn_add').on('click', event => {
            var personId = $('#person').val();
            var week = $('#week').val();
            var day = $('#day').val();
            var hour = $('#hour').val();
            console.log(personId+week+day+hour);
            $.post('https://localhost:5001/bookings',{
                Week : week,
                DayOfWeek :day,
                Hour : hour,
                PersonId : personId
            })
        });
        $.getJSON('https://localhost:5001/persons').then(data => {
            data.forEach(element => {
                console.log(element.firstname)
                $('<option>')
                .val(element.id)
                .html(element.firstname +" "+ element.lastname)
                .appendTo('#person')
            })
        })
        
    }
    function createPerson(){
        $("#addBooking")
        .append('<input id="firstname"></input>')
        .append('<input id="lastname"></input>')
        .append('<input id="age" type="number"></input>')
        .append('<button type="button" id="btn_add" class="btn btn-dark">Add</button>')
        $('#btn_add').on('click', event => {
            var firstname = $('#firstname').val();
            var lastname = $('#lastname').val();
            var age = $('#age').val();
            console.log(firstname+lastname+age);
            $.post('https://localhost:5001/persons',{
                firstname : firstname,
                lastname : lastname,
                age : age
            })
        });
    }
    
    createButtonsAndTables();

});
/*
<table class="table table-dark table-striped">
    <thead>
      <tr>
        <th scope="col">Nachname</th>
        <th scope="col">Vorname</th>
        <th scope="col">Alter</th>
        <th scope="col">#Reservierungen</th>
      </tr>
    </thead>
    <tbody id="tableCols">
    </tbody>
  </table>
  */