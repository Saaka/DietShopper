import {useState, useEffect} from "react";

function useDocumentTitle(pageTitle) {
    const appName = "DietShopper";

    useEffect(() => {

        function setDocumentTitle(title) {
            document.title = title;
        }

        if (!!pageTitle)
            setDocumentTitle(`${pageTitle} - ${appName}`)
        else
            setDocumentTitle(appName);

        return () => {
            setDocumentTitle(appName);
        };
    });
}

export {useDocumentTitle};