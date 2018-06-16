class Battlefield extends React.Component {

    constructor(props) {
        super(props);
        this.state = { map: [] };

        //this.onAddPhone = this.onAddPhone.bind(this);
        //this.onRemovePhone = this.onRemovePhone.bind(this);
    }

    // загрузка данных
    loadData() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ map: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadData();
    }

    render() {

        let int = this.state.map.LenghtX;
        let hexes = this.state.map.Hexes;
        console.log(hexes);   

        let xRad = 50;
        let yRad = xRad * 0.866;

        let x1 = 0 - xRad / 2;
        let y1 = 0 - yRad;
        let x2 = xRad/2;
        let y2 = y1;
        let x3 = xRad;
        let y3 = 0;
        let x4 = x2;
        let y4 = yRad;
        let x5 = x1;
        let y5 = y4;
        let x6 = 0 - xRad;
        let y6 = y3;

        if (hexes != undefined) {

            let rows = [];

            let xOffset = xRad * (1.5 * this.state.map.OffsetX + 2);
            let yOffset = yRad * (2 * this.state.map.OffsetY + 2);

            for (let i = 0; i < hexes.length; i++) {
                rows.push(<HexFrame key={hexes[i].ID} xRad={xRad} yRad={yRad} xCenter={xOffset} yCenter={yOffset} xCoord={hexes[i].X} yCoord={hexes[i].Y} x1={x1} y1={y1} x2={x2} y2={y2} x3={x3} y3={y3} x4={x4} y4={y4} x5={x5} y5={y5} x6={x6} y6={y6} />);
            }

            console.log(rows);

            return <svg height="720" width="1020" style={{ position: 'absolute', top: '0px', left: '0px' }}>
                {rows}
            </svg>;
        }
        else {
            return <div>
                <p>{int}</p>
            </div>;
        }

    }
}