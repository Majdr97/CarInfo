$(function () {
    loadCarMakes();
    initSelect2();
    initDatePicker();
});

function initSelect2() {
    $("#carMake").select2({ placeholder: "Select a Car Make", allowClear: true });
}

function initDatePicker() {
    $("#manufactureYear").datepicker({
        format: "yyyy",
        viewMode: "years",
        minViewMode: "years",
        autoclose: true
    });
}

function loadCarMakes() {
    $.get("/Index?handler=CarMakes", function (data) {
        let select = $("#carMake");
        select.append('<option value="">Select Make</option>');
        data.carMakeList.forEach(item => {
            select.append(`<option value="${item.id}">${item.name}</option>`);
        });
        select.select2({ placeholder: "Select a Car Make", allowClear: true });
    });
}

function getVehicleTypes() {
    let makeId = $("#carMake").val();
    if (!makeId) {
        Swal.fire("Warning", "Please select a car make!", "warning");
        return;
    }

    $.get(`/Index?handler=VehicleTypes&makeId=${makeId}`, function (data) {
        if (data.vehicleTypeList.length === 0) {
            Swal.fire("No Data", "No vehicle types found for this make.", "info");
            return;
        }
        $('#vehicleTypesTable').DataTable().clear().destroy();

        let table = $('#vehicleTypesTable').DataTable({
            data: data.vehicleTypeList,
            columns: [
                { data: 'id' },
                { data: 'name' }
            ]
        });
    });
}

function getCarModels() {
    let makeId = $("#carMake").val();
    let modelYear = $("#manufactureYear").val();
    if (!makeId || !modelYear) {
        Swal.fire("Warning", "Please select a car make and enter a manufacture year!", "warning");
        return;
    }

    $.get(`/Index?handler=CarModels&makeId=${makeId}&modelYear=${modelYear}`, function (data) {
        if (data.carModelList.length === 0) {
            Swal.fire("No Data", "No car models found for this make and year.", "info");
            return;
        }
        $('#carModelsTable').DataTable().clear().destroy();

        let table = $('#carModelsTable').DataTable({
            data: data.carModelList,
            columns: [
                { data: 'id' },
                { data: 'name' },
                { data: 'modelID' },
                { data: 'modelName' }
            ]
        });
    });
}