class Battlefield extends React.Component {

    constructor(props) {
        super(props);
        this.state = { map: [] };

        //this.onAddPhone = this.onAddPhone.bind(this);
        //this.onRemovePhone = this.onRemovePhone.bind(this);
    }

    // загрузка данных
    loadMapData() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiMapUrl, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ map: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadMapData();
    }

    render() {

        ////// variables initialise //////
        const xRad = 40;
        const yRad = xRad * 0.866;

        const x1Gap = 0 - xRad / 2;
        const y1Gap = 0 - yRad;
        const x2Gap = xRad / 2;
        const y2Gap = y1Gap;
        const x3Gap = xRad;
        const y3Gap = 0;
        const x4Gap = x2Gap;
        const y4Gap = yRad;
        const x5Gap = x1Gap;
        const y5Gap = y4Gap;
        const x6Gap = 0 - xRad;
        const y6Gap = y3Gap;

        let xCoord = 0;
        let yCoord = 0;
        let xOffset = 0;
        let yOffset = 0;
        let xCenter = 0;
        let yCenter = 0;
        let hexId = 0;

        let topHexId = 0;
        let topRightHexId = 0;
        let bottomRightHexId = 0;
        let bottomHexId = 0;
        let bottomLeftHexId = 0;
        let topLeftHexId = 0;

        let rows = [];

        let hexAbsCoords = [];

        let x1 = 0;
        let y1 = 0;
        let x2 = 0;
        let y2 = 0;
        let x3 = 0;
        let y3 = 0;
        let x4 = 0;
        let y4 = 0;
        let x5 = 0;
        let y5 = 0;
        let x6 = 0;
        let y6 = 0;

        let xMax = this.props.xMax;
        let yMax = this.props.yMax;

        let hexes = this.state.map.Hexes;

        ///// drawing hexes frames ///////
        if (hexes != undefined) {

            xMax = xRad * (1.5 * this.state.map.LengthX + 3);
            yMax = yRad * (2 * this.state.map.LengthY + 2);

            rows = [];
            hexAbsCoords = [];

            xCenter = xRad * (1.5 * this.state.map.OffsetX + 2);
            yCenter = yRad * (2 * this.state.map.OffsetY + 2);

            for (let i = 0; i < hexes.length; i++) {

                hexId = hexes[i].ID;

                xCoord = hexes[i].X;
                yCoord = hexes[i].Y;

                topHexId = hexes[i].TopHexId;
                topRightHexId = hexes[i].TopRightHexId;
                bottomRightHexId = hexes[i].BottomRightHexId;
                bottomHexId = hexes[i].BottomHexId;
                bottomLeftHexId = hexes[i].BottomLeftHexId;
                topLeftHexId = hexes[i].TopLeftHexId;

                if (xCoord % 2 == 0) {
                    xOffset = xCenter + xRad * (xCoord * 1.5);
                    yOffset = yCenter + yCoord * yRad * 2;
                }
                else {
                    xOffset = xCenter + xRad * (xCoord * 1.5);
                    yOffset = yCenter + yRad * yCoord * 2 + yRad;
                }

                hexAbsCoords.push({ x: xOffset, y: yOffset });

                x1 = xOffset + x1Gap;
                y1 = yOffset + y1Gap;
                x2 = xOffset + x2Gap;
                y2 = yOffset + y2Gap;
                x3 = xOffset + x3Gap;
                y3 = yOffset + y3Gap;
                x4 = xOffset + x4Gap;
                y4 = yOffset + y4Gap;
                x5 = xOffset + x5Gap;
                y5 = yOffset + y5Gap;
                x6 = xOffset + x6Gap;
                y6 = yOffset + y6Gap;

                rows.push(<HexFrame key={hexId} hexId={hexId} xCoord={xCoord} yCoord={yCoord} x1={x1} y1={y1} x2={x2} y2={y2} x3={x3} y3={y3} x4={x4} y4={y4} x5={x5} y5={y5} x6={x6} y6={y6} onhexclick={this.props.onhexclick} topHexId={topHexId} topRightHexId={topRightHexId} bottomRightHexId={bottomRightHexId} bottomHexId={bottomHexId} bottomLeftHexId={bottomLeftHexId} topLeftHexId={topLeftHexId} />);
            }

            return <svg height={yMax} width={xMax} style={{ position: 'absolute', top: '0px', left: '0px' }}>                
                <UnitsLayer apiUnitsUrl={document.getElementById("GetUnitsUrl").innerHTML} hexCoords={hexAbsCoords} />
                {rows}
            </svg>;
        }
        else {
            return <div>
                <p>Error occured!!!</p>
            </div>;
        }

    }
}