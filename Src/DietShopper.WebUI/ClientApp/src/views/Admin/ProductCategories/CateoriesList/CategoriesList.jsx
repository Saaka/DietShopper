import React, {useState, useEffect} from "react"
import "./CategoriesList.scss";

export function CategoriesList(props) {

    return (
        <div>
            <table className="table is-hoverable is-fullwidth">
                <tbody>
                {props.categories.map(cat =>
                    (
                        <tr key={cat.productCategoryGuid}>
                            <td>{cat.name}</td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}