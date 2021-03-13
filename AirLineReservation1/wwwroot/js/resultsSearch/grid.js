$(document).ready(function() {
    var movies = [
        { "rank": 1, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Budapesta", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 2, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Bucharest", "DepartureTime": "12:30", "Arrival": "Madrid", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 3, "Aircraft": "Qatar", "Date": "22.03.2020", "Departure": "Timisoara", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Business", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 4, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Timisoara", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 4, "Aircraft": "Qatar", "Date": "01.03.2011", "Departure": "Budapesta", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 6, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Budapesta", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 7, "Aircraft": "Qatar", "Date": "24.10.2011", "Departure": "Budapesta", "DepartureTime": "12:40", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 8, "Aircraft": "Qatar", "Date": "28.10.2011", "Departure": "Budapesta", "DepartureTime": "02:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 9, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Budapesta", "DepartureTime": "12:30", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
        { "rank": 10, "Aircraft": "Qatar", "Date": "22.10.2011", "Departure": "Budapesta", "DepartureTime": "01:40", "Arrival": "Londra", "ArrivalTime": "12:30", "Class": "Economy", "Capacity": 100, "Price": "500$", "RemainSeats": 100 },
    ];

    let kendoGrid = null;
    _populateGrid(movies);
    _searchData();

    function _searchData() {
        let $gridSearchInput = $(".k-input");
        $gridSearchInput.attr("id", "gridSearchInputId");
        let $gridSearchInputId = $("#gridSearchInputId");
        $gridSearchInputId.addClass("d-none");
        let searchValue = localStorage.getItem("searchValue")
        $gridSearchInputId.val(searchValue);



        var grid = $("#grid").data("kendoGrid");

        var $filter = {
            logic: "or",
            filters: [{
                field: 'Departure',
                operator: "contains",
                value: searchValue
            }, {
                field: 'Arrival',
                operator: "contains",
                value: searchValue
            }, {
                field: 'Class',
                operator: "contains",
                value: searchValue

            }]
        }




        grid.dataSource.filter($filter);
        $gridSearchInputId.on("keypress", function() {

            console.log("click", $(this).val());
        })

    }


    function _populateGrid(data) {

        kendoGrid = $("#grid").kendoGrid({
            dataSource: {
                data: data,
                pageSize: 20
            },
            height: 550,
            groupable: true,
            sortable: true,
            toolbar: ["search"],
            pageable: {
                refresh: true,
                pageSizes: true,
                buttonCount: 5
            },
            columns: [{
                    field: "rank",
                    title: "rank"
                }, {
                    field: "Aircraft",
                    title: "Aircraft"
                }, {
                    field: "Date",
                    title: "Date"

                }, {
                    field: "Departure",
                    title: "Departure"
                },

                {
                    field: "DepartureTime",
                    title: "Departure Time"
                },
                {
                    field: "Arrival",
                    title: "Arrival"

                },
                {

                    field: "ArrivalTime",
                    title: "Arrival Time"
                }, {
                    field: "Class",
                    title: "Class"
                },
                {

                    field: "ArrivalTime",
                    title: "Arrival Time"

                }, {
                    field: "Capacity",
                    title: "Capacity"
                }, {
                    field: "Price",
                    title: "Price"
                }, {
                    field: "RemainSeats",
                    title: "Remain Seats"

                }
            ]
        });
    }
});