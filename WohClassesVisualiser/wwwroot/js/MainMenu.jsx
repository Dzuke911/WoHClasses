class MainMenu extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    logout(e) {
        e.preventDefault();
        window.location = this.props.signoutUrl;
    }

    render() {
        return <div id="InfoPannel" style={{ float: 'left', border: '3px solid #000', height: '726px', width: '300px' }}>
            <p>InfoPannel</p>
            <p>{this.props.type}</p>
            <p>{this.props.data}</p>
            <form action={this.props.signoutUrl} method="post" onSubmit={this.logout}>
                <input type="submit" className="btn btn-primary form-control" name="SignOut" value="SignOut" />
            </form>
        </div>;
    }
}