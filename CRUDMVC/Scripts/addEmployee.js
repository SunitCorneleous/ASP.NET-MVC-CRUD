$(document).ready(function () {
    $("#openModal").click(
        function () {

            $('.modal-title').text("Add Employee");
            $('#addEmployeeButton').text("Add");

            $("#ename").val("");
            $("#eemail").val("");
            $("#eaddress").val("");
            $("#eposition").val("");

        }
    )

    $("#addEmployeeButton").click(function () {
        var addOrUpdateActionButton = $("#addEmployeeButton").text();

        // Add Employee
        if (addOrUpdateActionButton === "Add") {
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

            if (Name && Email && Address && Position) {
                console.log("add api call");

                $.post("https://localhost:44395/Employee/CreateEmployee",
                    {
                        emodel: employee
                    },
                    function (data, status) {
                        console.log(data);

                        location.reload(true);
                    });
            }
        }

        
    });


});