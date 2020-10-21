import React from "react"
import {useDocumentTitle} from "Hooks";
import "./Dashboard.scss";

function Dashboard(props) {
    useDocumentTitle("Dashboard");

    return (
        <section className="section center">
            <div>
                <figure className="image is-128x128 has-border">
                    <img src="https://picsum.photos/128/128/" alt="Logo" style={{maxWidth: "256px"}}/>
                </figure>
            </div>
        </section>
    );
}

export {Dashboard};