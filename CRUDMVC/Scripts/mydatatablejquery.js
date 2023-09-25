$(document).ready(
    function () {
        var employeeId;
        var employeeData;

        var table = $("#employeeTable").DataTable({
            "ajax": {
                "url": "/Employee/GetEmployeeData",
                "type": "GET",
                "datatype": "json",
                "dataSrc": function (json) {
                    return json.data;
                },
            },
            "columns": [
                { "title": "Id", data: "EmployeeId" },
                { "title": "Name", data: "Name" },
                { "title": "Email", data: "Email" },
                { "title": "Address", data: "Address" },
                { "title": "Position", data: "Position" },
                { "title": "Edit", data: "Position" },
                { "title": "Delete", data: "Position" },

            ],
            "columnDefs": [
                {
                    "targets": 5,
                    "render": function (data, type, row, meta) {
                        if (type === 'display') {
                            return '<button class="btn btn-primary" id="editButton" data-toggle="modal" data-target="#myModal">Edit</button>';
                        }
                        return data;
                    },
                },
                {
                    "targets": -1,
                    "render": function (data, type, row, meta) {
                        if (type === 'display') {
                            return '<button class="btn btn-danger" id="deleteButton" data-toggle="modal" data-target="#deleteModal">Delete</button>';
                        }
                        return data;
                    },
                },
            ],
        })

        $('#employeeTable').on('click', '#editButton', function () {
            let parentOfBtn = this.parentElement;

            employeeId = parentOfBtn.parentElement.childNodes[0].innerText;

            $('.modal-title').text("Edit Employee");
            $('#addEmployeeButton').text("Update");

            $.ajax({
                "url": "/Employee/GetEmployeeById/" + employeeId,
                "type": "GET",
                "datatype": "json",
                "success": function (data) {
                    employeeData = JSON.parse(data.data);

                    $("#ename").val(employeeData.Name);
                    $("#eemail").val(employeeData.Email);
                    $("#eaddress").val(employeeData.Address);
                    $("#eposition").val(employeeData.Position);
                },
            })

        });

        $('#employeeTable').on('click', '#deleteButton', function () {
            let parentOfBtn = this.parentElement;

            let elementArr = parentOfBtn.parentElement.childNodes;

            employeeId = elementArr[0].innerText;

        });

        // Delete Employee
        $('#deleteEmployeeButton').click(function () {

            $.post(`https://localhost:44395/Employee/DeleteEmployee?id=${employeeId}`,
                {},
                function (data, status) {
                    console.log(data);

                    $('#deleteModal').modal('hide')

                    table.ajax.reload();
                });
        });

        // Update Employee
        $("#addEmployeeButton").click(function () {
            var addOrUpdateActionButton = $("#addEmployeeButton").text();

            if (addOrUpdateActionButton === "Update") {

                let name = $("#ename").val();
                let email = $("#eemail").val();
                let address = $("#eaddress").val();
                let position = $("#eposition").val();

                let employee = {
                    name,
                    email,
                    address,
                    position
                }

                if (name && email && address && position) {
                    console.log("update api call");

                    $.post("https://localhost:44395/Employee/UpdateEmployee",
                        {
                            id: employeeData.EmployeeId,
                            data: employee
                        },
                        function (data, status) {
                            console.log(data);

                            $('#myModal').modal('hide');

                            table.ajax.reload();
                        });
                }

            }
        });

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

                            $('#myModal').modal('hide');

                            table.ajax.reload();
                        });
                }
            }


        });

    }
)