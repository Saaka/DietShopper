import React, {useState, useEffect} from "react"
import "./CategoriesList.scss";

export function CategoriesList(props) {

    return (
        <div>
            <table className="table is-hoverable is-fullwidth is-striped">
                <tbody>
                {props.categories.map(cat =>
                    (
                        <tr>
                            <td>{cat.name}</td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}