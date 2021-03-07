// @ts-check

import L from "leaflet";
import "leaflet/dist/leaflet.css";
// @ts-ignore
import icon from "leaflet/dist/images/marker-icon.png";
// @ts-ignore
import iconShadow from "leaflet/dist/images/marker-shadow.png";

// Fix for icon images, see https://github.com/Leaflet/Leaflet/issues/4968#issuecomment-264311098
L.Marker.prototype.options.icon = L.icon({
    iconUrl: icon,
    shadowUrl: iconShadow
});

/**
 * @param {L.Marker} marker
 * @param {boolean} isOpen
 */
function handlePopup(marker, isOpen) {
    if (isOpen) {
        marker.openPopup();
    } else {
        marker.closePopup();
    }
}

/**
 * @param {Model} model
 * @returns {(x: Model) => void}
 */
export function initMap(model) {
    const map = L.map(model.containerId).setView([51.505, -0.09], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    const marker = L.marker([51.5, -0.09]).addTo(map)
        .bindPopup('A pretty CSS3 popup.<br> Easily customizable.');

    handlePopup(marker, model.isPopupOpen);
    return (x) => handlePopup(marker, x.isPopupOpen);
}