$(document).ready(
    function () {
        $("#employeeTable").DataTable({
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

            ]
        })
    }
)