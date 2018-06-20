class HexFrame extends React.Component {

    constructor(props) {
        super(props);        

        this.click = this.click.bind(this);
    }

    click() {
        let hexId = this.props.hexId;
        let xCoord = this.props.xCoord;
        let yCoord = this.props.yCoord;

        this.props.onhexclick("hexInfo", "hexId=" + hexId + " ,x=" + xCoord + " ,y=" + yCoord + " ,near hexes = " +
            this.props.topHexId + "," +
            this.props.topRightHexId + "," +
            this.props.bottomRightHexId + "," +
            this.props.bottomHexId + "," +
            this.props.bottomLeftHexId + "," +
            this.props.topLeftHexId);
    }

    render() {

        x1 = this.props.x1;
        y1 = this.props.y1;
        x2 = this.props.x2;
        y2 = this.props.y2;
        x3 = this.props.x3;
        y3 = this.props.y3;
        x4 = this.props.x4;
        y4 = this.props.y4;
        x5 = this.props.x5;
        y5 = this.props.y5;
        x6 = this.props.x6;
        y6 = this.props.y6;

        let pts = "" + x1 + "," + y1 + "," + x2 + "," + y2 + "," + x3 + "," + y3 + "," + x4 + "," + y4 + "," + x5 + "," + y5 + "," + x6 + "," + y6;

        return <polygon points={pts} onClick={this.click} hexid={this.props.hexId} xcoord={this.props.xCoord} ycoord={this.props.yCoord} style={{ strokeOpacity: '0.3', fillOpacity: '0.0', stroke: 'black', strokeWidth: '1' }} />;
    }
}