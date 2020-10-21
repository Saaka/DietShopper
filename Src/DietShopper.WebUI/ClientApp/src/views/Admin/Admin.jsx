import React, {useEffect} from "react"
import {useHistory} from "react-router-dom";
import {useDocumentTitle} from "Hooks";
import {RouteNames} from "routes/names";
import "./Admin.scss";

function Admin(props) {
    useDocumentTitle("Admin page");
    const history = useHistory();

    function redirectTo(route) {
        history.push(route);
    }

    return (
        <section className="columns">
            <div className="column is-half-desktop is-offset-3-desktop">
                <p className="title has-text-light">Admin Page</p>
                <div className="tile is-ancestor">
                    <div className="tile is-parent" onClick={() => redirectTo(RouteNames.AdminProducts)}>
                        <div className="tile box">
                            <div className="content">
                                <p className="title">Products</p>
                                <p className="subtitle">Manage categories, configure the nutritional values and units of
                                    measures available for each product</p>
                            </div>
                        </div>
                    </div>
                    <div className="tile is-parent" onClick={() => redirectTo(RouteNames.AdminUnitsOfMeasures)}>
                        <div className="tile box">
                            <div className="content">
                                <p className="title">Units of measures</p>
                                <p className="subtitle">Setup units of measures</p>
                            </div>
                        </div>
                    </div>
                    <div className="tile is-parent" onClick={() => redirectTo(RouteNames.AdminProductCategories)}>
                        <div className="tile box">
                            <div className="content">
                                <p className="title">Product Categories</p>
                                <p className="subtitle">Manage product categories</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

export {Admin};