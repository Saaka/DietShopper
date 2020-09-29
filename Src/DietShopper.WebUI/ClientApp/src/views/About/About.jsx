import React from "react";

const About = (props) => {

    return (
        <div className="columns">
            <div className="column is-half is-offset-3">
                <div className="tile is-parent">
                    <article className="tile is-child notification is-primary">
                        <p className="title">DietShopper</p>
                        <p className="subtitle">Manage your recipes, create shopping lists and more to come. Stay tuned!</p>
                        <div className="content">
                            Please visit my <a href="https://github.com/Saaka/DietShopper" className="is-italic">GitHub page</a> to see the source code for this project.
                        </div>
                    </article>
                </div>
            </div>
        </div>
    );
};

export {About};