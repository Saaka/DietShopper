import React from "react"
import {useDocumentTitle} from "Hooks";
import "./Dashboard.scss";

function Dashboard(props) {
    useDocumentTitle("Dashboard");

    return (
        <section className="section columns is-centered">
            <div className="column is-half-desktop">
                <div className="tile is-parent">
                    <div className="tile box" onClick={() => console.log("recipes") /*redirectTo(RouteNames.MyRecipes)*/}>
                        <div className="content">
                            <p className="title">My Recipes</p>
                            <p className="subtitle">Manage your recipes</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

export {Dashboard};