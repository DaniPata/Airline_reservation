$(document).ready(function() {

    _setValueInlocalStorage();

    function _setValueInlocalStorage() {

        let $fromInputFlight = $("#fromInputFlight");

        $("#searchFlight").on('click', function() {

            console.log("aici ar trebui sa intre", $fromInputFlight.val());

            localStorage.setItem("searchValue", $fromInputFlight.val());

        })


    }
    _setValueInlocalStorage1();

    function _setValueInlocalStorage1() {

        let $toInputFlight1 = $("#toInputFlight1");

        $("#searchFlight").on('click', function() {

            console.log("aici ar trebui sa intre", $toInputFlight1.val());

            localStorage1.setItem("searchValue", $toInputFlight1.val());

        })
    }

    _setValueInlocalStorage2();

    function _setValueInlocalStorage2() {

        let $w3_country1 = $("#w3_country1");

        $("#searchFlight").on('click', function() {

            console.log("aici ar trebui sa intre", $w3_country1.val(select));

            localStorage2.setItem("searchValue", $w3_country1.val(select));

        })
    }

});