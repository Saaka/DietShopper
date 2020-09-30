import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"

const Icon = (props) => {

    const brands = ["google", "facebook-f"];
    function getIcon() {
        if (brands.indexOf(props.name) >= 0)
            return ["fab", props.name];

        return props.name;
    }

    return (
        <FontAwesomeIcon {...props} icon={getIcon()} spin={props.spin} />
    );
};

export { Icon };