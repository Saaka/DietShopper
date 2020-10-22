import React from "react"
import {useDocumentTitle} from "Hooks";
import {Icon} from "components/common";
import "./ProductCategories.scss";

function ProductCategories(props) {
    useDocumentTitle("Product categories - Admin page")

    return (
        <section className="columns is-centered">
            <div className="column is-half-desktop">
                <p className="title has-text-light">Products categories</p>
                <div className="columns columns-content">
                    <div className="column is-half">
                        <div className="box">
                            <p className="subtitle">Categories list</p>
                        </div>
                    </div>
                    <div className="column is-half">
                        <div className="box">
                            <p className="subtitle">Add category</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

export {ProductCategories};