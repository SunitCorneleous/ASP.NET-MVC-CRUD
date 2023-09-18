$(document).ready(function () {
    $("#addEmployeeButton").click(function () {
        let Name = $("#ename").val();
        let Email = $("#eemail").val();
        let Address = $("#eaddress").val();
        let Position = $("#eposition").val();

        let employee = {
            Name,
            Email,
            Address,
            Position
        }

        $.post("https://localhost:44395/Employee/CreateEmployee",
            {
                emodel: employee
            },
            function (data, status) {
                console.log(data)
            });
    });
});