import React from "react"
import {useDocumentTitle} from "Hooks";
import "./ProductCategories.scss";

function ProductCategories(props) {
    useDocumentTitle("Product categories - Admin page")

    return (
        <section className="columns">
            <div className="column is-half-desktop is-offset-3-desktop">
                <p className="title has-text-light">Products categories</p>
            </div>
        </section>
    );
}

export {ProductCategories};