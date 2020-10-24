import React, {useState, useEffect} from "react"
import {Icon} from "components/common";
import "./CategoriesList.scss";

export function CategoriesList(props) {

    function edit(category){
        props.onEdit(category);        
    }

    function remove(category){

    }
    
    return (
        <div>
            <table className="table is-hoverable is-fullwidth">
                <tbody>
                {props.categories.map(cat =>
                    (
                        <tr key={cat.productCategoryGuid} className={props.editedCategory === cat ? "is-selected" : ""}>
                            <td>{cat.name}</td>
                            <td className="list-action" onClick={(ev) => edit(cat)}><Icon name="edit" /></td>
                            <td className="list-action" onClick={(ev) => remove(cat)}><Icon name="ban" /></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}