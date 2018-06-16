class HexFrame extends React.Component {
    render() {
        let xCoord = this.props.xCoord;
        let yCoord = this.props.yCoord;
        let xRad = this.props.xRad;
        let yRad = this.props.yRad;
        let xCenter = this.props.xCenter;
        let yCenter = this.props.yCenter;

        let xOffset = 0;
        let yOffset = 0;

        if (xCoord % 2 == 0) {
            xOffset = xCenter + xRad * (xCoord * 1.5);
            yOffset = yCenter + yCoord * yRad * 2;
        }
        else {
            xOffset = xCenter + xRad * (xCoord * 1.5);
            yOffset = yCenter + yRad * yCoord * 2 + yRad;
        }

        x1 = xOffset + this.props.x1;
        y1 = yOffset + this.props.y1;
        x2 = xOffset + this.props.x2;
        y2 = yOffset + this.props.y2;
        x3 = xOffset + this.props.x3;
        y3 = yOffset + this.props.y3;
        x4 = xOffset + this.props.x4;
        y4 = yOffset + this.props.y4;
        x5 = xOffset + this.props.x5;
        y5 = yOffset + this.props.y5;
        x6 = xOffset + this.props.x6;
        y6 = yOffset + this.props.y6;

        let coords = "";

        let pts = coords + x1 + "," + y1 + "," + x2 + "," + y2 + "," + x3 + "," + y3 + "," + x4 + "," + y4 + "," + x5 + "," + y5 + "," + x6 + "," + y6;

        return <polygon points={pts} style={{ fillOpacity: '0.0', stroke: 'black', strokeWidth: '1' }} />;
    }
}