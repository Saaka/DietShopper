import React from "react"
import {useDocumentTitle} from "Hooks";
import "./UnitsOfMeasures.scss";

function UnitsOfMeasures(props) {
    useDocumentTitle("Units of measures - Admin page")
    return (
        <section className="columns is-centered">
            <div className="column is-half-desktop">
                <p className="title has-text-light">Units of measures</p>
            </div>
        </section>
    );
}

export {UnitsOfMeasures};