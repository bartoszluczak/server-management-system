import React, {useEffect, useState} from "react";
import WidgetContainer from "../UI/WidgetContainer";

const CurrentTime: React.FC= () => {
    const [currentTime, setCurrentTime] = useState(new Date().toLocaleTimeString())

    useEffect(() => {
        setInterval(() => {
            setCurrentTime(new Date().toLocaleTimeString());
        }, 1000);
    }, [currentTime])

    return (
        <WidgetContainer>
            <h3>Current time</h3>
            <h2>{new Date().toLocaleString().slice(0,10)}</h2>
            <h1>{currentTime}</h1>
        </WidgetContainer>
    )
}

export default CurrentTime;