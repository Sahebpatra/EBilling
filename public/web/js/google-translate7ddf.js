function myMap() {
        var mapProp = {
            center: new google.maps.LatLng(21.2160975, 72.8630322),
            zoom: 5,
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    }

    function googleTranslateElementInit() {
      new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
    }