namespace usb.View
{
    public class DeviceInfo
    {
        private string? id;
        private string? description;
        private string? manufacturer;
        private string? name;
        private string? status;
        private string? service;
        private string? caption;
        private string? pnpDeviceID;
        private string? configManagerErrorCode;
        private string? configManagerUserConfig;

        public DeviceInfo(string? id, string? description, string? manufacturer, string? name, string? status, string? service, string? caption, string? pnpDeviceID, string? configManagerErrorCode, string? configManagerUserConfig)
        {
            this.id = id;
            this.description = description;
            this.manufacturer = manufacturer;
            this.name = name;
            this.status = status;
            this.service = service;
            this.caption = caption;
            this.pnpDeviceID = pnpDeviceID;
            this.configManagerErrorCode = configManagerErrorCode;
            this.configManagerUserConfig = configManagerUserConfig;
        }
    }
}