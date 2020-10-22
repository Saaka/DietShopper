import React from "react"
import {useDocumentTitle} from "Hooks";
import {CategoryForm} from "./CategoryForm/CategoryForm";
import "./ProductCategories.scss";

function ProductCategories(props) {
    useDocumentTitle("Product categories - Admin page")

    function renderForm() {
        return (
            <div className="box">
                <CategoryForm/>
            </div>
        );
    }

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
                        {renderForm()}
                    </div>
                </div>
            </div>
        </section>
    );
}

export {ProductCategories};