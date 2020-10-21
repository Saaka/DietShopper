import React from "react"
import {useDocumentTitle} from "Hooks";
import "./UnitsOfMeasures.scss";

function UnitsOfMeasures(props) {
    useDocumentTitle("Units of measures - Admin page")
    return (
        <section className="columns">
            <div className="column is-half-desktop is-offset-3-desktop">
                <p className="title has-text-light">Units of measures</p>
            </div>
        </section>
    );
}

export {UnitsOfMeasures};