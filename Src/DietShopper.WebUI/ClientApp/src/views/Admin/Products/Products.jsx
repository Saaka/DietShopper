import React from "react"
import {useDocumentTitle} from "Hooks";
import "./Products.scss";

function Products(props) {
    useDocumentTitle("Products - Admin page");

    return (
        <section className="columns">
            <div className="column is-half-desktop is-offset-3-desktop">
                <p className="title has-text-light">Products</p>
            </div>
        </section>
    );
}

export {Products};