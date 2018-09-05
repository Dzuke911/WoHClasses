var React = require('react');

class UnitBox extends React.Component {

    constructor(props) {
        super(props)
    }

    gradToRad(angle) {
        return angle * Math.PI / 180;
    }

    render() {

        const rad = 25;

        let xCenter = this.props.xCenter;
        let yCenter = this.props.yCenter;

        let turnAngle = 0;

        switch (this.props.direction) {
            case "Top":
                turnAngle = 0;
                break;
            case "TopRight":
                turnAngle = 60;
                break;
            case "BottomRight":
                turnAngle = 120;
                break;
            case "Bottom":
                turnAngle = 180;
                break;
            case "BottomLeft":
                turnAngle = 240;
                break;
            case "TopLeft":
                turnAngle = 300;
                break;
        }


        x1 = xCenter + rad * Math.cos(this.gradToRad(50 - turnAngle));
        y1 = yCenter + rad * Math.sin(this.gradToRad(50 - turnAngle));
        x2 = xCenter + rad * Math.cos(this.gradToRad(25 - turnAngle));
        y2 = yCenter + rad * Math.sin(this.gradToRad(25 - turnAngle));
        x3 = xCenter + rad * Math.cos(this.gradToRad(0 - turnAngle - 25));
        y3 = yCenter + rad * Math.sin(this.gradToRad(0 - turnAngle - 25));
        x4 = xCenter + rad * Math.cos(this.gradToRad(0 - turnAngle - 155));
        y4 = yCenter + rad * Math.sin(this.gradToRad(0 - turnAngle - 155));
        x5 = xCenter + rad * Math.cos(this.gradToRad(0 - turnAngle - 205));
        y5 = yCenter + rad * Math.sin(this.gradToRad(0 - turnAngle - 205));
        x6 = xCenter + rad * Math.cos(this.gradToRad(0 - turnAngle - 230));
        y6 = yCenter + rad * Math.sin(this.gradToRad(0 - turnAngle - 230));

        let pts;

        if (this.props.type == "normal") {
            pts = "" + x1 + "," + y1 + "," + x2 + "," + y2 + "," + x3 + "," + y3 + "," + x4 + "," + y4 + "," + x5 + "," + y5 + "," + x6 + "," + y6;
            return <polygon points={pts} unitid={this.props.UnitId} style={{ fillOpacity: '0.0', stroke: 'blue', strokeWidth: '2' }} />;
        }

    }

}

module.exports = UnitBox;