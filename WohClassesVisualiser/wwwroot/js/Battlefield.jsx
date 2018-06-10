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
        return <div>
            <p>{int}</p>
        </div>;
    }
}