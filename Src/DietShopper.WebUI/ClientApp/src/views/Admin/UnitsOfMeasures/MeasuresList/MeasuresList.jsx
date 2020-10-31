import React from "react";
import "./MeasuresList.scss";

export const MeasuresList = ({measures, onEdit}) => {

    return (
        <div>
            <table className="table is-hoverable is-fullwidth">
                <thead>
                <tr>
                    <td>Name</td>
                </tr>
                </thead>
                <tbody>
                {measures.map(measure =>
                    (
                        <tr key={measure.measureGuid} onClick={(ev) => onEdit(measure)}>
                            <td>{measure.name}</td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}