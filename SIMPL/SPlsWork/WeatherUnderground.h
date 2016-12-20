namespace WeatherUnderground;
        // class declarations
         class WeatherChn;
         class Features;
         class Response;
         class Image;
         class DisplayLocation;
         class ObservationLocation;
         class Estimated;
         class CurrentObservation;
         class RootObject;
     class WeatherChn 
    {
        // class delegates
        delegate INTEGER_FUNCTION OutputDelegate ( SIMPLSHARPSTRING str );

        // class events

        // class functions
        FUNCTION getWeather ();
        FUNCTION SendtoSIMPL ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING ZipCode[];
        STRING APIKey[];
        STRING City[];
        STRING Condition[];
        STRING Temp[];
        STRING TempString[];
        STRING Humidity[];
        STRING WindDirection[];
        STRING WindSpeed[];
        STRING ConditionURL[];
        STRING LastUpdated[];

        // class properties
        DelegateProperty OutputDelegate myDel;
    };

     class Features 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER conditions;
    };

     class Response 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING version[];
        STRING termsofService[];
        Features features;
    };

     class Image 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING url[];
        STRING title[];
        STRING link[];
    };

     class DisplayLocation 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING full[];
        STRING city[];
        STRING state[];
        STRING state_name[];
        STRING country[];
        STRING country_iso3166[];
        STRING zip[];
        STRING magic[];
        STRING wmo[];
        STRING latitude[];
        STRING longitude[];
        STRING elevation[];
    };

     class ObservationLocation 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING full[];
        STRING city[];
        STRING state[];
        STRING country[];
        STRING country_iso3166[];
        STRING latitude[];
        STRING longitude[];
        STRING elevation[];
    };

     class Estimated 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class CurrentObservation 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Image image;
        DisplayLocation display_location;
        ObservationLocation observation_location;
        Estimated estimated;
        STRING station_id[];
        STRING observation_time[];
        STRING observation_time_rfc822[];
        STRING observation_epoch[];
        STRING local_time_rfc822[];
        STRING local_epoch[];
        STRING local_tz_short[];
        STRING local_tz_long[];
        STRING local_tz_offset[];
        STRING weather[];
        STRING temperature_string[];
        STRING relative_humidity[];
        STRING wind_string[];
        STRING wind_dir[];
        SIGNED_LONG_INTEGER wind_degrees;
        SIGNED_LONG_INTEGER wind_gust_mph;
        SIGNED_LONG_INTEGER wind_gust_kph;
        STRING pressure_mb[];
        STRING pressure_in[];
        STRING pressure_trend[];
        STRING dewpoint_string[];
        SIGNED_LONG_INTEGER dewpoint_f;
        SIGNED_LONG_INTEGER dewpoint_c;
        STRING heat_index_string[];
        STRING heat_index_f[];
        STRING heat_index_c[];
        STRING windchill_string[];
        STRING windchill_f[];
        STRING windchill_c[];
        STRING feelslike_string[];
        STRING feelslike_f[];
        STRING feelslike_c[];
        STRING visibility_mi[];
        STRING visibility_km[];
        STRING solarradiation[];
        STRING UV[];
        STRING precip_1hr_string[];
        STRING precip_1hr_in[];
        STRING precip_1hr_metric[];
        STRING precip_today_string[];
        STRING precip_today_in[];
        STRING precip_today_metric[];
        STRING icon[];
        STRING icon_url[];
        STRING forecast_url[];
        STRING history_url[];
        STRING ob_url[];
        STRING nowcast[];
    };

     class RootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Response response;
        CurrentObservation current_observation;
    };

