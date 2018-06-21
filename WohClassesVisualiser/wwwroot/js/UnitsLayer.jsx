class UnitsLayer extends React.Component {

    constructor(props) {
        super(props)

        this.state = {units : []}
    }

    loadUnitsData() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUnitsUrl, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({units : data});
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadUnitsData();
    }

    render() {

        const hexCoords = this.props.hexCoords;

        let result = [];
        let position;
        let unitName;

        let xCenter;
        let yCenter;

        let units = this.state.units.GameUnits;

        if (units != undefined) {

            result = [];

            for (let i = 0; i < units.length; i++) {

                position = units[i].UnitPosition;
                unitName = units[i].UnitTypeName;
                direction = units[i].UnitDirection;

                xCenter = hexCoords[position].x;
                yCenter = hexCoords[position].y;

                result.push(<UnitBox key={i} type="normal" unitName={unitName} direction={direction} xCenter={xCenter} yCenter={yCenter} />);
            }

        }

        return <g>
            {result}
            </g>;

    }
}