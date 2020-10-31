import React from "react";
import {Icon} from "components/common";
import "./MeasuresList.scss";

export const MeasuresList = ({measures, onEdit, onRemove}) => {

    return (
        <div>
            <table className="table is-hoverable is-fullwidth">
                <thead>
                <tr>
                    <td>Name</td>
                    <td />
                    <td />
                </tr>
                </thead>
                <tbody>
                {measures.map(measure =>
                    (
                        <tr key={measure.measureGuid}>
                            <td>{measure.name}</td>
                            <td className="list-action" onClick={(ev) => onEdit(measure)}><Icon name="edit"/></td>
                            <td className="list-action" onClick={(ev) => onRemove(measure)}><Icon name="ban"/></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}