sabio.services.products = sabio.services.products || {};

//....// ================================================ INSERT ==============================================
sabio.services.products.insert = function (data, onSuccess, onError)
{
    var url = "/api/products/";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);

};





//....// ================================================ UPDATE ==============================================
sabio.services.products.update = function (id, data, onSuccess, onError)
{
    var url = "/api/products/" + id;

    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: data
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };

    $.ajax(url, settings);

};





//....// ================================================ GET ==============================================
sabio.services.products.get = function (onAjaxSuccess, onAjaxError)
{
    var url = "/api/products/";

    var settings = {
        cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , dataType: "json"
            , success: onAjaxSuccess
            , error: onAjaxError
            , type: "GET"
    };

    $.ajax(url, settings);

};





//....// ================================================ GET BY PRODUCT ID ==============================================
sabio.services.products.getById = function (id, onSuccess, onError)
{
    var url = "/api/products/" + id;

    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);

};





//....// ================================================ GET BY COMPANY ID ==============================================
sabio.services.products.getByCompanyId = function (onAjaxSuccess, onAjaxError)
{
    var url = "/api/products/companyid";

    var settings = {
        cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , dataType: "json"
            , success: onAjaxSuccess
            , error: onAjaxError
            , type: "GET"
    };

    $.ajax(url, settings);

};





//....// ================================================ GET COMMENTS BY PRODUCT ID ======================================
sabio.services.products.commentsByProduct = function (id, onSuccess, onError)
{
    var url = "/api/products/" + id + "/comments";

    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);

};





//....// ================================================ DELETE BY PRODUCT ID =============================================
sabio.services.products.delete = function (id, onSuccess, onError)
{
    var url = "/api/products/" + id;

    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "DELETE"
    };

    $.ajax(url, settings);

};